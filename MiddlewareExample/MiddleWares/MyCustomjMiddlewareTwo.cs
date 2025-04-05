namespace MiddlewareExample.MiddleWares
{
    public class MyCustomjMiddlewareTwo: IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Response.WriteAsync("Hello world from my custom middleware two!");
            // Custom logic before the next middleware
            await next(context);
            // Custom logic after the next middleware
            context.Response.WriteAsync("Bye world from my custom middleware two!");
        }
    }
}
