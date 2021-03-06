﻿using WebSaude.Data.Context;
using WebSaude.Domain.Contracts.Repositories;
using WebSaude.Domain.Entities;

namespace WebSaude.Data.Repositories
{
    public class ProfissionalAcessoRepository : Repository<ProfissionalAcesso>, IProfissionalAcessoRepository
    {
        public ProfissionalAcessoRepository(WebSaudeContext context) : base(context)
        {
        }
    }
}
