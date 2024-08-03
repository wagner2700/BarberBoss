using BarberBoss.Communication.Response;
using BarberBoss.Infraestructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BarberBoss.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is ErrorOnValidatorException)
            {

            }
            else
            {
                ThrowUnknowError(context);
            }
        }

        private void HandleProjectException(ExceptionContext context)
        {

        }

        private void ThrowUnknowError(ExceptionContext context)
        {
            var responseError = new ResponseErrorJson("Erro desconhecido");
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            context.Result = new ObjectResult(responseError);


        }
    }

   
}
