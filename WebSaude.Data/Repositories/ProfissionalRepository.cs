using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebSaude.Data.Context;
using WebSaude.Domain.Contracts.Repositories;
using WebSaude.Domain.Entities;

namespace WebSaude.Data.Repositories
{
    public class ProfissionalRepository : Repository<Profissional>, IProfissionalRepository
    {
        public ProfissionalRepository(WebSaudeContext context) : base(context)
        {
        }
    }
}
