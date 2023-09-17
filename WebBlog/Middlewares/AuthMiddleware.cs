using WebBlog.Utils;

namespace WebBlog.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            if (httpContext.Request.Path == "/Blogs/Create")
            {
                if (httpContext.Request.Cookies.ContainsKey("jwt"))
                {
                    JwtUtils jwtUtl = new JwtUtils();
                    string cookieValue = httpContext.Request.Cookies["jwt"];
                    if (jwtUtl.ValidToken(cookieValue))
                    {
                        await _next(httpContext);
                        return;
                    }
                }
                httpContext.Response.Redirect("/Authentication/Login");
            }
            await _next(httpContext);
        }

        private static bool IsHomePath(HttpContext context)
        {

            return context.Request.Path.StartsWithSegments("/Home", StringComparison.OrdinalIgnoreCase);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }
}
