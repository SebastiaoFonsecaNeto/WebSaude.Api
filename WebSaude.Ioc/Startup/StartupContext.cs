using Microsoft.Extensions.DependencyInjection;
using WebSaude.Data.Context;

namespace WebSaude.Ioc.Startup
{
    public class StartupContext
    {
        public static void CreateConection(IServiceCollection services, string banco)
        {
            WebSaudeContext.CreateConection(services, banco);
        }
    }
}
