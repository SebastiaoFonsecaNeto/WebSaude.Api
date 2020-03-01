using System.Collections.Generic;
using WebSaude.Domain.Dtos;
using WebSaude.Domain.Entities;

namespace WebSaude.Domain.Contracts.Services
{
    public interface IProfissionalService : IService<Profissional>
    {
        Profissional Login(LoginDto login);
        Profissional RefreshToken(string token);
        Permissao ConsultaMenu(int profissionalId);
    }
}
