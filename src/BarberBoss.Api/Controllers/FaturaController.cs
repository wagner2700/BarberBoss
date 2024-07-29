using BarberBoss.Application.UseCases.Registrar;
using BarberBoss.Communication.Request;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaturaController : ControllerBase
    {

        [HttpPost]
        public IActionResult RegistrarFatura(RegistrarFaturaRequestJson request , IRegistrarFaturaUseCase useCase)
        {
            useCase.Registrar(request);

            return Ok();
        }
    }
}
