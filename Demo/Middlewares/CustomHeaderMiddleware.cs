using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Demo.Middlewares
{
    public class CustomHeaderMiddleware
    {
        private readonly RequestDelegate next;

        public CustomHeaderMiddleware(RequestDelegate next)
        {
            this.next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("***********custom HEader Called****************");
            context.Response.Headers.Add("X-custom-standard", "test");
            await next(context);
            
        }
    }
}
