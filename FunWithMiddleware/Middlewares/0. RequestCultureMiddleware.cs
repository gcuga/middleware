using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FunWithMiddleware.Middlewares
{
  public class RequestCultureMiddleware
  {
    private readonly RequestDelegate _next;

    public RequestCultureMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
      var cultureQuery = context.Request.Query["culture"];
      if (!string.IsNullOrWhiteSpace(cultureQuery))
      {
        var culture = new CultureInfo(cultureQuery);

        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
      }
      
      // Вызов следующего мидлваре в конвеере
      await _next(context);
    }
  }
}