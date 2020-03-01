using Microsoft.Extensions.DependencyInjection;
using WebSaude.Data.Repositories;
using WebSaude.Domain.Contracts.Repositories;

namespace WebSaude.Ioc.Repositories
{
    public class RepositoriesIoc 
    {
        public static void AdicionarDependencias(IServiceCollection services)
        {
            services.AddTransient<IProfissionalRepository, ProfissionalRepository>();
            services.AddTransient<IPacienteRepository, PacienteRepository>();
            services.AddTransient<IProfissionalAcessoRepository, ProfissionalAcessoRepository>();
            services.AddTransient<IObjetoRepository, ObjetoRepository>();
            services.AddTransient<IObjetoFilhoRepository, ObjetoFilhoRepository>();
            services.AddTransient<IPermissaoRepository, PermissaoRepository>();
            services.AddTransient<IPermissaoItemRepository, PermissaoItemRepository>();
            services.AddTransient<IUnidadeRepository, UnidadeRepository>();
            services.AddTransient<IProfissionalUnidadeRepository, ProfissionalUnidadeRepository>();
        }
    }
}
