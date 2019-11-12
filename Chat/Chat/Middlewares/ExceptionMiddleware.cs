using System;
using System.Net;
using System.Threading.Tasks;
using Chat.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Chat.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NoPermissionsException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.Forbidden);
            }
            catch (IncorrectParametersException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest,
                    new { error = ex.Message, ex.Parameters });
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex, HttpStatusCode statusCode, object parameters = null)
        {
            if (context.Response.HasStarted)
            {
                throw ex;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            var result = JsonConvert.SerializeObject(parameters);

            return context.Response.WriteAsync(result);
        }
    }
}
