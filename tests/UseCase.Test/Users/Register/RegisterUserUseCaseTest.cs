using BarberBoss.Application.UseCases.User;
using CommonTestsLibraries;
using CommonTestsLibraries.Mapper;
using CommonTestsLibraries.Repositories;
using FluentAssertions;

namespace UseCase.Test.Users.Register
{
    public class RegisterUserUseCaseTest
    {
        [Fact]
        public async Task Sucess()
        {
            var request = RequestRegisterUserJsonBuilder.Build();
            var useCase = CreateUseCase();
            var result = await useCase.Execute(request);

            result.Should().NotBeNull();
            result.Name.Should().Be(request.Name);
            result.Token.Should().NotBeNullOrWhiteSpace();
        }

        private RegisterUserUseCase CreateUseCase()
        {

            var mapper = MapperBuilder.Build();
            var unitOfWork = UnitOfWorkBuilder.Build();
            var registerUser = RegisterUserRepositoryBuilder.Build();
            var tokenGerator = TokenGeneratorBuilder.Build();
            var passwordEncripter = PasswordEncripterBuilder.Build();

            return new RegisterUserUseCase(registerUser, mapper, unitOfWork, passwordEncripter, null, tokenGerator);
        }
    }
}
