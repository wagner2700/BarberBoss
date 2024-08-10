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
            CreateMap<RegisterBillRequestJson, Fatura>();
        }

        private void EntityToRequest()
        {
            CreateMap<Fatura, ResponseFaturaJson>();
            
        }
    }
}
