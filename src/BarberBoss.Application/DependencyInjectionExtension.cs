using BarberBoss.Application.AutoMapper;
using BarberBoss.Application.UseCases.Bill;
using BarberBoss.Infraestructure.DataAcess;
using Microsoft.Extensions.DependencyInjection;


namespace BarberBoss.Application
{
    public static class DependencyInjectionExtension
    {
        
        public static void AddApplication(this IServiceCollection service)
        {
            
            AddUseCase(service);
            AutoMapper(service);

            service.AddScoped<IBillGetByIdUseCase, BillGetByIdUseCase>();
        }

        private static void AutoMapper( IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }

        private static void AddUseCase(IServiceCollection service)
        {
            service.AddScoped<IRegisterBillUseCase, RegisterBillUseCase>();
            service.AddScoped<IDeleteBillUseCase, DeleteBillUseCase>();
            service.AddScoped<IUpdateBillUseCase, UpdateBillUseCase>();
        }
    }
}
