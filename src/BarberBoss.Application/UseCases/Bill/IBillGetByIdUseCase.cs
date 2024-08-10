using BarberBoss.Communication.Response;
using BarberBoss.Domain.Entities;

namespace BarberBoss.Application.UseCases.Bill
{
    public interface IBillGetByIdUseCase
    {
        Task<ResponseFaturaJson> GetById(long id);
    }
}
