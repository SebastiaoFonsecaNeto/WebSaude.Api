using WebSaude.Data.Context;
using WebSaude.Domain.Contracts.Repositories;
using WebSaude.Domain.Entities;

namespace WebSaude.Data.Repositories
{
    public class UnidadeRepository : Repository<Unidade>, IUnidadeRepository
    {
        public UnidadeRepository(WebSaudeContext context) : base(context)
        {
        }
    }
}
