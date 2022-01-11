using System;
using System.Net;
using System.Threading.Tasks;
using Core.Exceptions;
using Microsoft.AspNetCore.Http;

namespace WebExperience.Test.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ApiNotFoundException exception)
            {
                await HandleExceptionAsync(httpContext, exception.Message, HttpStatusCode.NotFound);
            }
            catch (Exception)
            {
                await HandleExceptionAsync(httpContext, "An error has occurred. Please contact your administrator for more information.", HttpStatusCode.InternalServerError);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, string message, HttpStatusCode httpStatusCode)
        {
            context.Response.StatusCode = (int)httpStatusCode;

            return context.Response.WriteAsync(message);
        }

    }
}
