using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSaude.Domain.Contracts.Services;
using WebSaude.Domain.Entities;

namespace WebSaude.Api.Controllers
{
    /// <inheritdoc />
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProfissionaisController : ControllerBase
    {
        private readonly IProfissionalService _profissionalService;

        /// <inheritdoc />
        public ProfissionaisController(IProfissionalService profissionalService)
        {
            _profissionalService = profissionalService;
        }

        /// <summary>
        /// Consultar profissionais cadastrados
        /// </summary>
        /// <param name="nome">Filtrar profissionais por nome informado </param>
        /// <returns>Lista de profissionais encontrados </returns>
        [HttpGet]
        public ActionResult<IEnumerable<Profissional>> Get([FromQuery] string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return _profissionalService.Get(new List<string> { "Acesso", "Unidades" }).ToList();

            return _profissionalService.Get(new List<string> { "Acesso", "Unidades" }).Where(p => p.Nome.ToLower().Contains(nome.ToLower())).ToList();
        }

        /// <summary>
        /// Consultar profissional por id
        /// </summary>
        /// <param name="id">Id do profissional que deseja consultar </param>
        /// <returns>Profissional relacionado ao Id </returns>
        [HttpGet("{id}")]
        public ActionResult<Profissional> GetById(int id)
        {
            return _profissionalService.Get(new List<string> { "Acesso", "Unidades" }).FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Incluir profissional
        /// </summary>
        /// <param name="profissional">Dados do profissional a ser incluído </param>
        [HttpPost]
        public void Post([FromBody] Profissional profissional)
        {
            _profissionalService.Add(profissional);
        }

        /// <summary>
        /// Alterar profissional
        /// </summary>
        /// <param name="id">Id do profissional a ser alterado </param>
        /// <param name="profissional">Dados do pacinte a ser alterado </param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Profissional profissional)
        {
            _profissionalService.Update(profissional);
        }

        /// <summary>
        /// Excluir profissional
        /// </summary>
        /// <param name="id">Id do profissional a ser excluído </param>
        /// <param name="profissional">Dados do profissional a ser excluído </param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _profissionalService.Delete(id);
        }
    }
}
