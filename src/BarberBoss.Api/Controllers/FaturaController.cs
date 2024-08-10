using BarberBoss.Application.UseCases.Bill;
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
        [ProducesResponseType(typeof(ResponseFaturaJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult>   RegistrarFatura(RegisterBillRequestJson request , [FromServices]IRegisterBillUseCase useCase)
        {
            var response = await useCase.Registrar(request);
            return Created(string.Empty , response); 
        }


        [HttpGet]
        [Route("id")]
        [ProducesResponseType(typeof(ResponseFaturaJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBillById(long id , [FromServices] IBillGetByIdUseCase useCase)
        {
            var response = await useCase.GetById(id);
            return Ok(response);
               


        }
    }
}
