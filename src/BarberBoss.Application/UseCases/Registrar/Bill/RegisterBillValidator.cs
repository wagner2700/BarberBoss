using BarberBoss.Communication.Request;
using BarberBoss.Domain.Entities;
using FluentValidation;

namespace BarberBoss.Application.UseCases.Registrar.Bill
{
    public class RegisterBillValidator : AbstractValidator<RegisterBillRequestJson>
    {

        public RegisterBillValidator()
        {
            RuleFor(bill => bill.Valor).GreaterThan(0).WithMessage("Valor deve ser maior que zero");
            RuleFor(bill => bill.Data).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Data não pode ser no futuro");
            RuleFor(bill => bill.TipoPagamento).IsInEnum().WithMessage("Tipo de pagamento inválido");
        }
    }
}
