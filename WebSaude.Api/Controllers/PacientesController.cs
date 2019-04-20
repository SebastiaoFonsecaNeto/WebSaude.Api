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
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        /// <inheritdoc />
        public PacientesController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        /// <summary>
        /// Consultar pacientes cadastrados
        /// </summary>
        /// <param name="nome">Filtrar pacientes por nome informado </param>
        /// <returns>Lista de pacientes encontrados </returns>
        [HttpGet]
        public ActionResult<IEnumerable<Paciente>> Get([FromQuery] string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return _pacienteService.Get().ToList();

            return _pacienteService.Get().Where(p => p.Nome.ToLower().Contains(nome.ToLower())).ToList();
        }

        /// <summary>
        /// Consultar paciente por id
        /// </summary>
        /// <param name="id">Id do paciente que deseja consultar </param>
        /// <returns>Paciente relacionado ao Id </returns>
        [HttpGet("{id}")]
        public ActionResult<Paciente> GetById(int id)
        {
            return _pacienteService.GetById(id);
        }

        /// <summary>
        /// Incluir paciente
        /// </summary>
        /// <param name="paciente">Dados do paciente a ser incluído </param>
        [HttpPost]
        public void Post([FromBody] Paciente paciente)
        {
            _pacienteService.Add(paciente);
        }

        /// <summary>
        /// Alterar paciente
        /// </summary>
        /// <param name="id">Id do paciente a ser alterado </param>
        /// <param name="paciente">Dados do pacinte a ser alterado </param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Paciente paciente)
        {
            _pacienteService.Update(paciente);
        }

        /// <summary>
        /// Excluir paciente
        /// </summary>
        /// <param name="id">Id do paciente a ser excluído </param>
        /// <param name="paciente">Dados do paciente a ser excluído </param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _pacienteService.Delete(id);
        }
    }
}
