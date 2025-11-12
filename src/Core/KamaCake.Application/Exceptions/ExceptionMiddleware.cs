    using FluentValidation;
    using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;

namespace KamaCake.Application.Exceptions
    {
        public class ExceptionMiddleware : IMiddleware
        {
            public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
            {
                try
                {
                    await next(httpContext);
                }
                catch (Exception ex) 
                { 
                    await HandleExceptionAsync(httpContext, ex);
                }
            }

            private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception) 
            {
                int statusCode = GetStatusCode(exception); 
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = statusCode;

                if(exception.GetType()== typeof(ValidationException))
                {
                    return httpContext.Response.WriteAsync(new ExceptionModel
                    {
                        Errors=((ValidationException)exception).Errors.Select(x=>x.ErrorMessage),
                        StatusCode= StatusCodes.Status400BadRequest
                    }.ToString());
                }

                List<string> errors = new()
                {
                    $"Xeta mesaji: {exception.Message}",
                   //$"Xeta aciqlamasi: {exception.InnerException?.ToString()}" 
                };
                return httpContext.Response.WriteAsync(new ExceptionModel
                {
                    Errors=errors,
                    StatusCode=statusCode
                }.ToString());
            }

            private static int GetStatusCode(Exception exception) =>
                exception switch
                {
                    BadRequestException => StatusCodes.Status400BadRequest,//case
                    NotFoundException => StatusCodes.Status400BadRequest,//case
                    ValidationException => StatusCodes.Status422UnprocessableEntity,//case
                    _ => StatusCodes.Status500InternalServerError //default 
                };
        }
    }
