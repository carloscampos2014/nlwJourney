using Journey.Communication.Responses;
using Journey.Exceptions;
using Journey.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Journey.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BaseException)
        {
            var exception = (BaseException)context.Exception;
            context.HttpContext.Response.StatusCode = (int)exception.GetStatusCode();
            context.Result = new ObjectResult(exception.GetErrorModel())
            {
                StatusCode = (int)exception.GetStatusCode(),
            };
        }
        else
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(
                new ErrorResponseJson(
                    ErrorMessages.TypeErrorUnknown,
                    [ErrorMessages.IntenalServerError]))
            {
                StatusCode = StatusCodes.Status500InternalServerError,
            };
        }
    }
}
