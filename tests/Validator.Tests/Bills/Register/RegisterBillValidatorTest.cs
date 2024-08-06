using BarberBoss.Application.UseCases.Registrar.Bill;
using BarberBoss.Communication.Request;
using BarberBoss.Domain.Entities;
using CommoTestsLibraries;
using FluentValidation;

namespace Validator.Tests.Bills.Register
{
    public class RegisterBillValidatorTest
    {

        [Fact]
        public void Sucess()
        {
            var validator = new RegisterBillValidator();

            var request = BillRequestBuilder.Build();

            //var request = new RegisterBillRequestJson
            //{
            //    Data = DateTime.UtcNow.AddDays(-1),
            //    Descricao = "teste",
            //    TipoPagamento = BarberBoss.Domain.Enums.TipoPagamento.CartaoCredito,
            //    Valor = 2
            //};

            var result = validator.Validate(request);

            Assert.True(result.IsValid);
        }
    }
}
