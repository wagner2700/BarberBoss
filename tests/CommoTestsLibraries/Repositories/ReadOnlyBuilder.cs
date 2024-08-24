using BarberBoss.Domain.Users;
using Moq;

namespace CommonTestsLibraries.Repositories
{
    public class ReadOnlyBuilder
    {
        private readonly Mock<IUserReadOnlyRepository> _repository;


        public ReadOnlyBuilder()
        {
            _repository = new Mock<IUserReadOnlyRepository>();
        }

        public IUserReadOnlyRepository Build() => _repository.Object;
    }
}
