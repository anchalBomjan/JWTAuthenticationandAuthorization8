using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.Eventing.Reader;

namespace AuthenticationandAuthorizationJWTToken9.Middleware
{
    public class CustomExceptionFilter:ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {


            if(context.Exception is KeyNotFoundException)
            {
                context.Result = new NotFoundObjectResult(new { message = context.Exception.Message });
            }
            else
            {
                context.Result = new ObjectResult(new
                {
                    message = "An Error occoured while processing you request"
                })
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }

            context.ExceptionHandled = true;
  
        }
        
    }
}
