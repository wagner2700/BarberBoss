using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Users
{
    public interface IRegisterUserRepository
    {
        Task Execute(User user);
    }
}
