namespace SystemManagement.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public class HeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public HeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var path = context.Request.Path.Value ?? string.Empty;
            if (path.StartsWith("/swagger", System.StringComparison.OrdinalIgnoreCase) ||
                path.StartsWith("/favicon.ico") ||
                path.StartsWith("/swagger-ui"))
            {
                await _next(context);
                return;
            }

            // Check for '
            // ' header
            if (!context.Request.Headers.ContainsKey("cnpj"))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Missing required header: cnpj");
                return;
            }

            await _next(context);
        }
    }
}
