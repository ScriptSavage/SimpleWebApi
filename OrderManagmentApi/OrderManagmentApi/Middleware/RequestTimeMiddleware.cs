using System.Diagnostics;

namespace OrderManagmentApi.Middleware;

public class RequestTimeMiddleware : IMiddleware
{
    
    private readonly ILogger<RequestTimeMiddleware> _logger;

    private Stopwatch s;
    
    public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
    {
        _logger = logger;
        s = new Stopwatch();
    }
    

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
                s.Start();
                await next.Invoke(context);
                s.Stop();
        }
        catch (Exception e)
        {
           var timeSpanMiliseconds = s.ElapsedMilliseconds;
           if (timeSpanMiliseconds / 1000 > 4)
           {
               _logger.LogInformation(e, "Request Time Too Long");
           }
        }
    }
}