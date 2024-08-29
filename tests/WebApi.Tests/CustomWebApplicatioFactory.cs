using BarberBoss.Domain.Entities;
using BarberBoss.Infraestructure.DataAcess;
using CommonTestsLibraries.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace CommonTestsLibraries
{
    public class CustomWebApplicatioFactory : WebApplicationFactory<Program>
    {
        private User _user; 

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test")
                .ConfigureServices(services =>
                {
                    var provider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                    services.AddDbContext<BarberBossDbContext>(config =>
                    {
                        config.UseInMemoryDatabase("InMemoryDbForTesting");
                        config.UseInternalServiceProvider(provider);
                    });
                    var scope = services.BuildServiceProvider().CreateScope();
                    var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();
                }); 
        }

        public string GetEmail() =>  _user.Email;
        public string GetPassword() => _user.Password;

        private void StartDatabase(BarberBossDbContext dbContext)
        {
            var _user = UserBuilder.Build();
            dbContext.Add(_user);
            dbContext.SaveChanges();

        }
    }
}
