using BarberBoss.Domain.Bills;
using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Register;
using Microsoft.EntityFrameworkCore;

namespace BarberBoss.Infraestructure.DataAcess.Repository
{
    public class RegistrarFaturaRepository : IRegisterFatura , IBillReadOnlyRepository
    {
        private readonly BarberBossDbContext _context;


        public RegistrarFaturaRepository(BarberBossDbContext context)
        {
            _context = context;
        }

        public async Task<Fatura?> GetById(long id)
        {
            return await _context.Fatura.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task RegisterBill(Fatura fatura)
        {
            await _context.Fatura.AddAsync(fatura);
            
        }

        
    }
}
