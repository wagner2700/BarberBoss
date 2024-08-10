using AutoMapper;
using BarberBoss.Application.UseCases.User.Validator;
using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;
using BarberBoss.Domain.Users;
using BarberBoss.Infraestructure.DataAcess;
using BarberBoss.Infraestructure.Exceptions;

namespace BarberBoss.Application.UseCases.User
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IRegisterUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserUseCase(IRegisterUserRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<ResponseUserJson> Execute(UserRequestJson request)
        {
            Validate(request);

            var user = _mapper.Map<BarberBoss.Domain.Entities.User>(request);

            await _repository.Execute(user);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseUserJson>(request); ;
        }


        private void Validate(UserRequestJson request)
        {
            var validate = new UserValidator();

            var result = validate.Validate(request);
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            if(result.IsValid is false)
            {
                throw new ErrorOnValidatorException(errorMessages);
            }
        }
    }
}
