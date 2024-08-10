namespace BarberBoss.Domain.Users
{
    public interface IUserReadOnlyRepository
    {
        Task<bool> EmailExist(string email);
    }
}
