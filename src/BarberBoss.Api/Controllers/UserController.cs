using BarberBoss.Application.UseCases.User;
using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseUserJson) , StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson) , StatusCodes.Status400BadRequest)]
        public  async Task RegisterUser([FromBody] UserRequestJson request ,[FromServices] IRegisterUserUseCase useCase)
        {
            await useCase.Execute(request);
            Ok(request);
        }
    }
}
