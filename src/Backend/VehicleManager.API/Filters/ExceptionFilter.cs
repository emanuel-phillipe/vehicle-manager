using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VehicleManager.Communication.Responses;
using VehicleManager.Exceptions;
using VehicleManager.Exceptions.ExceptionsBase;

namespace VehicleManager.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is VehicleManagerException) HandleProjectException(context);
        else
        {
            HandleUnknowException(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        if (context.Exception is ErrorValidationException)
        {
            // Trasnformar a exception em uma ErrorValidation, pois sabemos que ela é uma dessa
            var exception =  (ErrorValidationException)context.Exception;
            
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception.ErrorMessages));
        }
    }
    
    private void HandleUnknowException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessagesException.UNKNOW_ERROR));
    }
}