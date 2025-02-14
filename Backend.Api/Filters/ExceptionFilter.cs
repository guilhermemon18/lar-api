using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Backend.Api.dto;
using Backend.Api.Utils.Errors.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Backend.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is NotFoundException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Result = new NotFoundObjectResult(new JsonErrorDto(context.Exception.Message, (int)HttpStatusCode.NotFound));
            }
            else if (context.Exception is BadRequestException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new NotFoundObjectResult(new JsonErrorDto(context.Exception.Message, (int)HttpStatusCode.BadRequest));
            }
            // else if (context.Exception is ErrorOnValidationException)
            // {
            //     context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            //     context.Result = new BadRequestObjectResult(new ResponseErrorJson(context.Exception.Message));
            // }
            // else if (context.Exception is ConflictException)
            // {
            //     context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
            //     context.Result = new ConflictObjectResult(new ResponseErrorJson(context.Exception.Message));
            // }
            else //Erro genérico no Server:
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result = new ObjectResult(new JsonErrorDto("Unknown error", (int)HttpStatusCode.InternalServerError));
            }
        }



    }
}