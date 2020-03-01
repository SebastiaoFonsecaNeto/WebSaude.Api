using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WebSaude.Domain.Contracts.Repositories;
using WebSaude.Domain.Contracts.Services;
using WebSaude.Domain.Dtos;
using WebSaude.Domain.Entities;
using WebSaude.Domain.Resources;
using Microsoft.Extensions.Options;

namespace WebSaude.Service.Services
{
    public class ProfessionalService : Service<Profissional>, IProfissionalService
    {
        private readonly AppSettingsDto _appSettings;
        private readonly IProfissionalRepository _profissionalRepository;
        private readonly IProfissionalAcessoRepository _profissionalAcessoRepository;
        private readonly IPermissaoRepository _permissaoRepository;
        public ProfessionalService(IProfissionalRepository professionalRepository,
                                   IProfissionalAcessoRepository profissionalAcessoRepository,
                                   IPermissaoRepository permissaoRepository,
                                   IOptions<AppSettingsDto> appSettings) : base(professionalRepository)
        {
            _profissionalRepository = professionalRepository;
            _profissionalAcessoRepository = profissionalAcessoRepository;
            _permissaoRepository = permissaoRepository;
            _appSettings = appSettings.Value;
        }
        public Profissional Login(LoginDto login)
        {
            var user = _profissionalRepository.Get(new List<string> { "Acesso", "Unidades" }).FirstOrDefault(p => p.Email.ToLower() == login.Email.ToLower());

            if (user == null)
                throw new ValidationException(ProfissionalResources.NaoCadastrado);

            if (user.Acesso?.Senha == null || login.Senha != user.Acesso?.Senha)
                throw new ValidationException(ProfissionalResources.SenhaInvalida);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            user.Acesso.Token = tokenHandler.WriteToken(token);
            user.Acesso.Ultimo = DateTime.Now;

            _profissionalAcessoRepository.Update(user.Acesso);

            user.Acesso.Senha = null;

            return user;
        }

        public Profissional RefreshToken(string token)
        {
            var profId = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims.FirstOrDefault(c => c.Type == "unique_name").Value;

            if (!int.TryParse(profId, out var id))
                throw new ValidationException(ProfissionalResources.NaoCadastrado);

            var user = _profissionalRepository.Get(new List<string> { "Acesso", "Unidades" }).FirstOrDefault(p => p.Id == id);

            if (user == null)
                throw new ValidationException(ProfissionalResources.NaoCadastrado);

            if (user?.Acesso == null)
                throw new ValidationException(ProfissionalResources.NaoCadastrado);

            if (user.Acesso.Token != token || DateTime.Now > user.Acesso.Ultimo.AddDays(1))
                throw new ValidationException(ProfissionalResources.TokenExpirado);

            return Login(new LoginDto { Email = user.Email, Senha = user.Acesso.Senha });
        }

        public Permissao ConsultaMenu(int profissionalId)
        {
            var user = _profissionalAcessoRepository.GetById(profissionalId);

            if (user == null)
                throw new ValidationException(ProfissionalResources.NaoCadastrado);

            return _permissaoRepository.Get(new List<string> { "Itens", "Itens.Objeto", "Itens.Objeto.Itens", "Itens.Objeto.Itens.Objeto" }).FirstOrDefault(p => p.Id == user.IdPermissao);
        }
    }
}
