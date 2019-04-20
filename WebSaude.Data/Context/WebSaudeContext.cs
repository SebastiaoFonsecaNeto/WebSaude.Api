using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebSaude.Data.Map;
using WebSaude.Domain.Entities;

namespace WebSaude.Data.Context
{
    public class WebSaudeContext : DbContext
    {
        public DbSet<Profissional> Profissional { get; set; }

        public WebSaudeContext(DbContextOptions<WebSaudeContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ObjetoMap());
            modelBuilder.ApplyConfiguration(new ObjetoFilhoMap());
            modelBuilder.ApplyConfiguration(new PacienteMap());
            modelBuilder.ApplyConfiguration(new PermissaoMap());
            modelBuilder.ApplyConfiguration(new PermissaoItemMap());
            modelBuilder.ApplyConfiguration(new ProfissionalMap());
            modelBuilder.ApplyConfiguration(new ProfissionalAcessoMap());
            modelBuilder.ApplyConfiguration(new ProfissionalUnidadeMap());
            modelBuilder.ApplyConfiguration(new UnidadeMap());
        }

        public static void CreateConection(IServiceCollection services, string banco)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<WebSaudeContext>(options => options.UseNpgsql(banco));
        }
    }
}
