using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Demo.Middlewares
{
    public class BannedFireFoxMiddleware
    {
        private readonly RequestDelegate next;

        public BannedFireFoxMiddleware(RequestDelegate next)
        {
            this.next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {

            var agent = context.Request.Headers["user-agent"].ToString();
            if (agent.Contains("Firefox"))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("access denied");
                return;
            }

            await next(context);

        }

    }
}
