using BarberBoss.Domain.Bills;
using BarberBoss.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarberBoss.Infraestructure.DataAcess.Repository
{
    public class RegistrarFaturaRepository :  IBillReadOnlyRepository , IBillWriteOnlyRepository , IBillUpdateOnlyRepository
    {
        private readonly BarberBossDbContext _context;


        public RegistrarFaturaRepository(BarberBossDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(long id)
        {
            var result = await _context.Fatura.FirstOrDefaultAsync(fatura => fatura.Id == id);  
            if (result is null)
            {
                return false;
            }
            _context.Fatura.Remove(result);
            return true;
        }

        async Task<Fatura?> IBillReadOnlyRepository.GetById(long id)
        {
            return await _context.Fatura.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
        }

        async Task<Fatura?> IBillUpdateOnlyRepository.GetById(long id)
        {
            return await _context.Fatura.FirstOrDefaultAsync(f => f.Id == id);

             
        }

        public async Task RegisterBill(Fatura fatura)
        {
            await _context.Fatura.AddAsync(fatura);
            
        }

        public void Update(Fatura fatura)
        {
            _context.Fatura.Update(fatura);
        }
    }
}
