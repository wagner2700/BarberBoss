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
            CreateMap<RequestBillJson, Fatura>();
            CreateMap<UserRequestJson, User>();
        }

        private void EntityToRequest()
        {
            CreateMap<Fatura, ResponseFaturaJson>();
            CreateMap<User, UserRequestJson>();
            
        }
    }
}
