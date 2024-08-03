using BarberBoss.Communication.Request;
using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Register
{
    public interface IRegisterFatura
    {
        void RegisterBill(Fatura fatura);
    }
}
