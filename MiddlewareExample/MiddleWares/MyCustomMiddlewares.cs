namespace MiddlewareExample.MiddleWares
{
    public class MyCustomMiddlewares : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Response.WriteAsync("Hello world from my custom middleware!\n");
            // Custom logic before the next middleware
            await next(context);
            // Custom logic after the next middleware
            context.Response.WriteAsync("Bye world from my custom middleware!\n");
        }
    }

    public static class MyCustomMiddlewaresExtensions
    {
        public static IApplicationBuilder UseMyCustomMiddlewares(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyCustomMiddlewares>();
        }
    }
}
