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

        public async Task Delete( User user, long id)
        {
            var result = await _context.Fatura.FirstOrDefaultAsync(fatura => fatura.Id == id && fatura.UserId == user.Id);  
            if(result != null)
            {
                _context.Fatura.Remove(result);
            }
            
            
        }

        async Task<Bill?> IBillReadOnlyRepository.GetById(long id)
        {
            return await _context.Fatura.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
        }

        async Task<Bill?> IBillUpdateOnlyRepository.GetById(User user,long id)
        {
            return await _context.Fatura.FirstOrDefaultAsync(f => f.Id == id && f.UserId == user.Id);

             
        }

        public async Task RegisterBill(Bill fatura)
        {
            await _context.Fatura.AddAsync(fatura);
            
        }

        public void Update(Bill fatura)
        {
            _context.Fatura.Update(fatura);
        }
    }
}
