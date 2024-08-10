using BarberBoss.Communication.Request;
using BarberBoss.Exception;
using FluentValidation;

namespace BarberBoss.Application.UseCases.Bill
{
    public class RegisterBillValidator : AbstractValidator<RegisterBillRequestJson>
    {

        public RegisterBillValidator()
        {
            RuleFor(bill => bill.Valor).GreaterThan(0).WithMessage(ResourceErrorMessages.ValorMaiorQueZero);
            RuleFor(bill => bill.Data).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.DataNaoFututo);
            RuleFor(bill => bill.TipoPagamento).IsInEnum().WithMessage(ResourceErrorMessages.PagamentoInválido);
        }
    }
}
