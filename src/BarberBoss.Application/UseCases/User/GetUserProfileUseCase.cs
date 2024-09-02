﻿
using AutoMapper;
using BarberBoss.Communication.Response;
using BarberBoss.Domain.Users;

namespace BarberBoss.Application.UseCases.User
{
    public class GetUserProfileUseCase : IGetUserProfileUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IMapper _mapper;

        public GetUserProfileUseCase(ILoggedUser loggedUser , IMapper mapper)
        {
            _loggedUser = loggedUser;
            _mapper = mapper;
        }

        public async Task<ResponseUserProfileJson> Execute()
        {
            var user = _loggedUser.Get();

            return _mapper.Map<ResponseUserProfileJson>(user);

        }
    }
}
