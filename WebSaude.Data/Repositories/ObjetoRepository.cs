using WebSaude.Data.Context;
using WebSaude.Domain.Contracts.Repositories;
using WebSaude.Domain.Entities;

namespace WebSaude.Data.Repositories
{
    public class ObjetoRepository : Repository<Objeto>, IObjetoRepository
    {
        public ObjetoRepository(WebSaudeContext context) : base(context)
        {
        }
    }
}
