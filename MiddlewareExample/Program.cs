using MiddlewareExample.MiddleWares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MiddlewareExample.MiddleWares.MyCustomMiddlewares>();
builder.Services.AddTransient<MiddlewareExample.MiddleWares.MyCustomjMiddlewareTwo>();
var app = builder.Build();

//middleware 1
app.UseMiddleware<MiddlewareExample.MiddleWares.MyCustomMiddlewares>();
 
// middleware 2
app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Hello world!");
    next(context);
    await context.Response.WriteAsync("Bye world!");
});

// middleware 3
//app.UseMiddleware<MiddlewareExample.MiddleWares.MyCustomjMiddlewareTwo>();
app.UseMyCustomMiddlewares();

// middleware 4
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello world from middleware 4!");
    next(context);
    await context.Response.WriteAsync("Bye world from middleware 4!");
});

// middleware 5
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Again Hello world!");
});

app.Run();
