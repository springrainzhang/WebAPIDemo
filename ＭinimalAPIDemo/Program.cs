using MVCAPIDemo.Action.Impl;
using MVCAPIDemo.Action;
using MVCAPIDemo.Models;
using Serilog;
using Microsoft.AspNetCore.Mvc.RazorPages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

UserActions userActions = new UserActions();


app.MapGet("/Login", () =>
{
    List<UserInfo> userList =  userActions.GetAllUser();
    logger.Information(new EventId(1001).ToString(), "Get all user");
    return Results.Ok(userList);
});

app.MapGet("/Login/{userNo:int}/{password=111}", (string userNo, string password) =>
{
    UserInfo user = userActions.CheckLogin(userNo, password);
    return user;
});

app.MapPost("/Login", (UserInfo user) =>
{
    return userActions.AddUser(user);
});

app.MapPut("/Login", (string userNo, string userName, int age, string password) =>
{
    return userActions.UpdateUser(userNo, userName, age, password);
});

app.MapDelete("/Login", (string userNo) =>
{
    return userActions.DeleteUser(userNo);
});

app.Use(async (context, next) =>
{
    var idQuery = context.Request.RouteValues["userNo"];
    if (idQuery != null && idQuery.Equals("1"))
    {
        context.Response.Headers.Add("X-Tag", "This is super user");
    }

    await next();
});

app.Run();
