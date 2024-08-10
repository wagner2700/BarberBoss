namespace BarberBoss.Domain.Security
{
    public interface IPasswordEncrypter
    {
        string Encrypt(string password);
    }
}
