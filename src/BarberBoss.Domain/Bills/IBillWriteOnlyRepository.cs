using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Bills
{
    public interface IBillWriteOnlyRepository
    {
        Task RegisterBill(Fatura fatura);
        Task<bool> Delete(long id);
        

    }
}
