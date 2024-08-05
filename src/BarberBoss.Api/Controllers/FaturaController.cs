using BarberBoss.Application.UseCases.Registrar.Bill;
using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;
using BarberBoss.Infraestructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaturaController : ControllerBase
    {

        [HttpPost]
        public IActionResult RegistrarFatura(RegisterBillRequestJson request , IRegisterBillUseCase useCase)
        {
            var response = useCase.Registrar(request);
            return Created(string.Empty , response); 
        }
    }
}
