namespace MVCAPIDemo.MiddleWare
{
    public static class MyCustomMiddleWareExtensions
    {
        public static IApplicationBuilder UseMyCustomMiddleWare1(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyCustomMiddleWare>();
        }
    }
}
