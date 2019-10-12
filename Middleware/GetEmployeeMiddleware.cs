using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace NetCoreApi3.Middleware
{
  public class GetEmployeeMiddleware
  {
    private readonly RequestDelegate _next;

    public GetEmployeeMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ILogger<GetEmployeeMiddleware> logger)
    {
      logger.LogInformation("Get Employee middleware invoked");
      await _next(context);
    }
  }

  public static class GetEmployeeMiddlewareExtensions
  {
    public static IApplicationBuilder UseGetEmployeeMiddleware(this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<GetEmployeeMiddleware>();
    }
  }
}