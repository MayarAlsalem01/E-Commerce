using App.Applcation.Common.Exceptions;
using App.Applcation.Common.Exceptions.Common;
using App.Applcation.Common.Exceptions.DomainException;
using App.Applcation.Common.Exceptions.LogicException;
using App.Applcation.Dtos.Response.Common;
using App.Applcation.Dtos.Response.Common.ExceptionsResponse;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.Infrastrcuture.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);   
            }catch (Exception ex)
            {
               await HandleExceptionAsync(context ,ex);
            }

        }
        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int code;
            var result=string.Empty;
            BaseErrorResponse errorResponse;
            switch (exception)
            {
                case EntityException ex:
                   
                    errorResponse = new EntityErrorResponse(
                        (int)HttpStatusCode.BadRequest, 
                        ex.Result.ToDictionary()
                        );                  
                        
                    break;
                case NotFoundException ex:
                    errorResponse=new LogicErrorResponse(ex.Code,ex.Message);
                    break;
                case ValidationException ex:
                    errorResponse = new ValidationExceptionResponse(400, ex.Message, ex.Result.ToDictionary());
                    break;
                default:
                    errorResponse = new ServerErrorRespose(exception.Message);
                    
                    break;
            }
            context.Response.StatusCode = errorResponse.StatusCode;
            context.Response.ContentType = "application/json";
            
            
           
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
        }
    }
}
