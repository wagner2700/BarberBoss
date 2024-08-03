using BarberBoss.Application.AutoMapper;
using BarberBoss.Application.UseCases.Registrar.Bill;
using Microsoft.Extensions.DependencyInjection;


namespace BarberBoss.Application
{
    public static class DependencyInjectionExtension
    {
        
        public static void AddApplication(this IServiceCollection service)
        {
            
            AddUseCase(service);
            AutoMapper(service);
        }

        private static void AutoMapper( IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }

        private static void AddUseCase(IServiceCollection service)
        {
            service.AddScoped<IRegisterBillUseCase, RegisterBillUseCase>();
            service.AddScoped<IRegisterBillUseCase, RegisterBillUseCase>();

        }
    }
}
