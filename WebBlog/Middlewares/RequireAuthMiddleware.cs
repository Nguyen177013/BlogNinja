using WebBlog.Models;
using WebBlog.Utils;

namespace WebBlog.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequireAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public RequireAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            JwtUtils jwtUtl = new JwtUtils();
            string cookieValue = httpContext.Request.Cookies["jwt"];
            if (cookieValue != null)
            {
                Author author = jwtUtl.ValidToken(cookieValue);
                httpContext.Items.Add("UserId", author.Id);
                httpContext.Items.Add("UserName", author.UserName);
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequireAuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequireAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequireAuthMiddleware>();
        }
    }
}
