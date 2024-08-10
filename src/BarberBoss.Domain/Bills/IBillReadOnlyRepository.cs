using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Bills
{
    public interface IBillReadOnlyRepository
    {
        Task<Fatura?> GetById(long id);
    }
}
