using Microsoft.Extensions.DependencyInjection;
using WebSaude.Domain.Contracts.Services;
using WebSaude.Service.Services;

namespace WebSaude.Ioc.Services
{
    public class ServicesIoc
    {
        public static void AdicionarDependencias(IServiceCollection services)
        {
            services.AddTransient<IPacienteService, PacienteService>();
            services.AddTransient<IProfissionalService, ProfessionalService>();
        }
    }
}
