using WebSaude.Data.Context;
using WebSaude.Domain.Contracts.Repositories;
using WebSaude.Domain.Entities;

namespace WebSaude.Data.Repositories
{
    public class ProfissionalUnidadeRepository : Repository<ProfissionalUnidade>, IProfissionalUnidadeRepository
    {
        public ProfissionalUnidadeRepository(WebSaudeContext context) : base(context)
        {
        }
    }
}
