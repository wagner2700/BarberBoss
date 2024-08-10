using BarberBoss.Domain.Security;
using BCrypt.Net ;

namespace BarberBoss.Infraestructure.Security
{
    public class BcryptPasswordEncryptor : IPasswordEncrypter
    {
        public string Encrypt(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
