using AutoMapper;
using BarberBoss.Communication.Request;
using BarberBoss.Domain.Bills;
using BarberBoss.Domain.Entities;
using BarberBoss.Exception;
using BarberBoss.Exception.Exceptions;
using BarberBoss.Infraestructure.DataAcess;
using BarberBoss.Infraestructure.Exceptions;

namespace BarberBoss.Application.UseCases.Bill
{
    internal class UpdateBillUseCase : IUpdateBillUseCase
    {
        private readonly IBillUpdateOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBillUseCase(IBillUpdateOnlyRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task Update(long id, RequestBillJson request)
        {
            Validate(request);

            var bill = await _repository.GetById(id);

            if(bill == null)
            {
                throw new RegisterNotFoundEception(ResourceErrorMessages.RegistroNaoEncontrado);
            }

            _mapper.Map(request , bill);
    
            _repository.Update(bill);
            await _unitOfWork.Commit();
        }


        private void Validate(RequestBillJson request)
        {
            var validate = new BillValidator();

            var result = validate.Validate(request);
            // Pegar mensagem
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            if (result.IsValid == false)
            {
                throw new ErrorOnValidatorException(errorMessages);
            }
        }
    }
}
