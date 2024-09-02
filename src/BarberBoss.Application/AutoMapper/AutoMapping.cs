using AutoMapper;
using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;
using BarberBoss.Domain.Entities;

namespace BarberBoss.Application.AutoMapper
{
    public class AutoMapping: Profile
    {
        public AutoMapping() 
        {
            RequestToEntity();
            EntityToRequest();
        }

        private void RequestToEntity()
        {
            CreateMap<RequestBillJson, Bill>();
            CreateMap<UserRequestJson, User>()
                .ForMember(user => user.Password , config => config.Ignore());
        }

        private void EntityToRequest()
        {
            CreateMap<Bill, ResponseFaturaJson>();
            CreateMap<User, UserRequestJson>();
            CreateMap<User, ResponseUserProfileJson>();
            
        }
    }
}
