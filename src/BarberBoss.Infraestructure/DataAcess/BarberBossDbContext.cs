using BarberBoss.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BarberBoss.Infraestructure.DataAcess
{
    public class BarberBossDbContext : DbContext
    {
        public DbSet<Fatura> Fatura {  get; set; }

        public BarberBossDbContext(DbContextOptions options) :  base(options) { }
        
    }
}
