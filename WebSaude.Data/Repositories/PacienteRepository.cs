using WebSaude.Data.Context;
using WebSaude.Domain.Contracts.Repositories;
using WebSaude.Domain.Entities;

namespace WebSaude.Data.Repositories
{
    public class PacienteRepository : Repository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(WebSaudeContext context) : base(context)
        {
        }
    }
}
