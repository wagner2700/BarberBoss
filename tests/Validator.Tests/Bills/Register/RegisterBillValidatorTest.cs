using CommoTestsLibraries;
using FluentAssertions;
using BarberBoss.Application.UseCases.Bill;
using BarberBoss.Exception;


namespace Validator.Tests.Bills.Register
{
    public class RegisterBillValidatorTest
    {

        [Fact]
        public void Sucess()
        {
            var validator = new BillValidator();

            var request = BillRequestBuilder.Build();

            var result = validator.Validate(request);

            result.IsValid.Should().Be(true);
        }

        [Fact]
        public void Amoun_Equals_Zero()
        {
            var request = BillRequestBuilder.Build();
            var validator = new BillValidator();

            request.Valor = 0;

            var result = validator.Validate(request);

            result.IsValid.Should().Be(false);
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.ValorMaiorQueZero));
        }
    }
}
