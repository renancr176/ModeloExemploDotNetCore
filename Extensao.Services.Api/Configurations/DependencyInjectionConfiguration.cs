using Extensao.Infra.CrossCuting.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Extensao.Services.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
