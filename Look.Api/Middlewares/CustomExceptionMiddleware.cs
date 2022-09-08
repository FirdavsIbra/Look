using Look.Service.Exceptions;

namespace Look.Api.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate next;
        public CustomExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (LookException ex)
            {
                await HandlerExceptionAsync(context, ex.Code, ex.Message);
            }
            catch (Exception ex)
            {
                await HandlerExceptionAsync(context, 500, ex.Message);
            }
        }

        public async Task HandlerExceptionAsync(HttpContext context, int code, string message)
        {
            context.Response.StatusCode = code;

            await context.Response.WriteAsJsonAsync(new
            {
                Code = code,
                Message = message,
            });

        }
    }

}
