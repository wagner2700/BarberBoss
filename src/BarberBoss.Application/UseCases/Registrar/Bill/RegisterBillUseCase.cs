using AutoMapper;
using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;
using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Register;
using BarberBoss.Infraestructure.Exceptions;

namespace BarberBoss.Application.UseCases.Registrar.Bill
{
    public class RegisterBillUseCase : IRegisterBillUseCase
    {
        private readonly IRegisterFatura _repositoryWriteOnly;
        private readonly IMapper _mapper;

        public RegisterBillUseCase(IRegisterFatura repositoryWriteOnly, IMapper mapper)
        {
            _repositoryWriteOnly = repositoryWriteOnly;
            _mapper = mapper;
        }
        public ResponseFaturaJson Registrar(RegisterBillRequestJson request)
        {
            Validate(request);
            var fatura = _mapper.Map<Fatura>(request);

            _repositoryWriteOnly.RegisterBill(fatura);
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
