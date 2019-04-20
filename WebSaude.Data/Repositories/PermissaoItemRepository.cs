using WebSaude.Data.Context;
using WebSaude.Domain.Contracts.Repositories;
using WebSaude.Domain.Entities;

namespace WebSaude.Data.Repositories
{
    public class PermissaoItemRepository : Repository<PermissaoItem>, IPermissaoItemRepository
    {
        public PermissaoItemRepository(WebSaudeContext context) : base(context)
        {
        }
    }
}
