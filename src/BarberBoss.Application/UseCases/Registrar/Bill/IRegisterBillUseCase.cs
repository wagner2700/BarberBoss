using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;

namespace BarberBoss.Application.UseCases.Registrar.Bill
{
    public interface IRegisterBillUseCase
    {

        ResponseFaturaJson Registrar(RegisterBillRequestJson request);
    }
}
