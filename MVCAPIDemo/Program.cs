using MVCAPIDemo.Action;
using MVCAPIDemo.Action.Impl;
using MVCAPIDemo.Controllers;
using MVCAPIDemo.MiddleWare;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<IUserActions, UserActions>();
//builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.UseMyCustomMiddleWare1();

app.Use(async (context, next) =>
{
    var idQuery = context.Request.RouteValues["userNo"];
    if (idQuery != null && idQuery.Equals("1"))
    {
        context.Response.Headers.Add("X-Tag", "This is super user");
    }

    await next();
});


app.MapControllers();

app.Run();
