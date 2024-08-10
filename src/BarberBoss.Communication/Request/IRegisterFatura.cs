using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Register
{
    public interface IRegisterFatura
    {
        Task RegisterBill(Fatura fatura);
    }
}
