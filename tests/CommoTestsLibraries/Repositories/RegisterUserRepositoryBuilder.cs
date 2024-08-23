using BarberBoss.Domain.Users;
using Moq;

namespace CommonTestsLibraries.Repositories
{
    public class RegisterUserRepositoryBuilder
    {
        public static IRegisterUserRepository Build()
        {
            var mock = new Mock<IRegisterUserRepository>();

            return mock.Object;
        }
    }
}
