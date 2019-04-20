using WebSaude.Domain.Contracts.Repositories;
using WebSaude.Domain.Contracts.Services;
using WebSaude.Domain.Entities;

namespace WebSaude.Service.Services
{
    public class PacienteService: Service<Paciente>, IPacienteService
    {
        public PacienteService(IPacienteRepository pacienteRepository) : base(pacienteRepository)
        {
        }
    }
}
