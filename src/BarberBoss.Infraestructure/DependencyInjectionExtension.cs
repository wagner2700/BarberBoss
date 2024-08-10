using BarberBoss.Domain.Bills;
using BarberBoss.Domain.Security;
using BarberBoss.Domain.Users;
using BarberBoss.Infraestructure.DataAcess;
using BarberBoss.Infraestructure.DataAcess.Repository;
using BarberBoss.Infraestructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BarberBoss.Infraestructure
{
    public static class DependencyInjectionExtension
    {

        public static void AddInfraestructure(this IServiceCollection service, IConfiguration configuration)
        {
            AddDbContext(service , configuration);
            AddRepository(service);


        }


        public static void AddRepository(IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<IBillWriteOnlyRepository, RegistrarFaturaRepository>();
            service.AddScoped<IBillReadOnlyRepository, RegistrarFaturaRepository>();
            service.AddScoped<IBillUpdateOnlyRepository, RegistrarFaturaRepository>();
            service.AddScoped<IUserReadOnlyRepository, UserRepository>();
            service.AddScoped<IRegisterUserRepository, UserRepository>();
            service.AddScoped<IPasswordEncrypter, BcryptPasswordEncryptor>();
        


        }

        private static void AddDbContext(IServiceCollection service , IConfiguration configuration )
        {

            var connection = configuration.GetConnectionString("Connection");
            var version = ServerVersion.AutoDetect(connection);

            service.AddDbContext<BarberBossDbContext>(config => config.UseMySql(connection , version));
        }
    }
}
