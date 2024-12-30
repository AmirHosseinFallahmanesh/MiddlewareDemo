using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Demo.Middlewares
{
    public class LogMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<LogMiddleware> logger;

        public LogMiddleware(RequestDelegate next,ILogger<LogMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            string rederer = context.Request.Headers["referrer"].ToString();
            string agent = context.Request.Headers["user-agent"].ToString();
            //string lang
            string ip = context.Request.HttpContext.Connection.RemoteIpAddress.ToString();


            logger.LogInformation("REQUEST REVICED " + DateTime.Now);
            await next(context);
        }
    }
}
