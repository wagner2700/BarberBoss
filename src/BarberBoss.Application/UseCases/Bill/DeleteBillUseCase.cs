
using BarberBoss.Domain.Bills;
using BarberBoss.Exception;
using BarberBoss.Exception.Exceptions;
using BarberBoss.Infraestructure.DataAcess;

namespace BarberBoss.Application.UseCases.Bill
{
    public class DeleteBillUseCase : IDeleteBillUseCase
    {
        private readonly IBillWriteOnlyRepository _repositoy;
        private readonly IUnitOfWork _unitOfWork;


        public DeleteBillUseCase(IBillWriteOnlyRepository repositoy, IUnitOfWork unitOfWork)
        {
            _repositoy = repositoy;
            _unitOfWork = unitOfWork;
        }
        public async Task Execute(long id)
        {
            var result = await _repositoy.Delete(id);


            if(result == false )
            {
                throw new RegisterNotFoundEception(ResourceErrorMessages.RegistroNaoEncontrado);
            }

            await _unitOfWork.Commit();
        }
    }
}
