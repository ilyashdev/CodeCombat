using System.Text;

namespace CodeCombat.Application_Layer.Middlewares;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var initData = 
        Encoding.UTF8.GetString(
            Convert.FromBase64String(
                context.Request.Form["initData"].ToString()));
        

        await _next.Invoke(context);
    }
}