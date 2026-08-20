using FILEAPI.Data.Request;
using FILEAPI.Data.Request.Exceptions;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FILEAPI.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _environment;
        public ExceptionHandlerMiddleware(RequestDelegate next, IHostEnvironment environment)
        {
            this._next = next; 
            this._environment = environment;
        }

        public async Task Task(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (HttpException ex)
            {

                await HandleException(ex, httpContext, (int)ex.StatusCode);
            }
            catch (Exception ex)
            {
                await HandleException(ex, httpContext, 500);
            }
        }

        public async Task HandleException(Exception ex, HttpContext httpContext,int statusCode) {
            
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            var response = new
            {
                Message = ex.Message,
                Details = _environment.IsDevelopment()? ex.StackTrace: ""

            };

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));

        }
}
}
