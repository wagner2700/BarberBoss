using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Register;

namespace BarberBoss.Infraestructure.DataAcess.Repository
{
    public class RegistrarFaturaRepository : IRegisterFatura
    {
        private readonly BarberBossDbContext _context;

        public RegistrarFaturaRepository(BarberBossDbContext context)
        {
            _context = context;
        }

        public void RegisterBill(Fatura fatura)
        {
            _context.Fatura.Add(fatura);
            _context.SaveChanges();
        }

        
    }
}
