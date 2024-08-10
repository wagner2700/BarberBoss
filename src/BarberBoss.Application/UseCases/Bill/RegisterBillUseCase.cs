using AutoMapper;
using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;
using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Register;
using BarberBoss.Infraestructure.DataAcess;
using BarberBoss.Infraestructure.Exceptions;

namespace BarberBoss.Application.UseCases.Bill
{
    public class RegisterBillUseCase : IRegisterBillUseCase
    {
        private readonly IRegisterFatura _repositoryWriteOnly;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public RegisterBillUseCase(IRegisterFatura repositoryWriteOnly, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repositoryWriteOnly = repositoryWriteOnly;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public async Task<ResponseFaturaJson> Registrar(RegisterBillRequestJson request)
        {
            Validate(request);
            var fatura = _mapper.Map<Fatura>(request);

            await _repositoryWriteOnly.RegisterBill(fatura);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseFaturaJson>(fatura);

        }


        private void Validate(RegisterBillRequestJson request)
        {
            var validate = new RegisterBillValidator();

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
