using System.Globalization;

namespace MVCAPIDemo.MiddleWare
{
    public class MyCustomMiddleWare
    {
        private readonly RequestDelegate _next;
        public MyCustomMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers.Add("X-Developed-By", "Rain");
           
            await _next(context);
        }
    }
}
