using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;

namespace OrderManagmentApi.Middleware;

public class BasicAuthMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Headers.ContainsKey("Authorization"))
        {
            var authHeader = AuthenticationHeaderValue.Parse(context.Request.Headers["Authorization"]);
        }
        
        context.Response.StatusCode = 401;
        context.Response.ContentType = "Unauthorized";
        
    }
}