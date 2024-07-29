using BarberBoss.Communication.Request;

namespace BarberBoss.Application.UseCases.Registrar
{
    public interface IRegistrarFaturaUseCase
    {

        void Registrar(RegistrarFaturaRequestJson request);
    }
}
