using BarberBoss.Application.UseCases.Registrar;
using Microsoft.Extensions.DependencyInjection;

namespace BarberBoss.Application
{
    public static class DependencyInjectionExtension
    {
        
        public static void AddScoped(this IServiceCollection service)
        {
            service.AddScoped<IRegistrarFaturaUseCase, RegistrarFaturaUseCase>();
        }
    }
}
