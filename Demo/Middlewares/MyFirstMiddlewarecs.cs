using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Middlewares
{
    public class MyFirstMiddleware
    {
        private readonly RequestDelegate next;

        public MyFirstMiddleware(RequestDelegate next)
        {
            this.next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("***********Simple Log For Data Hare****************");
            await next(context);
        }
    }
}
