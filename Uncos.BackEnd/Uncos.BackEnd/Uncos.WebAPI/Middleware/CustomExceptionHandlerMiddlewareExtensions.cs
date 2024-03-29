namespace Uncos.WebAPI.Middleware
{
    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        //это нужно для того чтобы добавлять Middleware конвеир
        public static IApplicationBuilder UseCustomExceptionHandler(this
            IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
