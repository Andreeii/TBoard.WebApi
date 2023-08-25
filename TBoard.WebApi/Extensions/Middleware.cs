using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace TBoard.WebApi.Extensions
{
    public class Middleware
    {
        private readonly RequestDelegate next;

        public Middleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Response.StatusCode == 404
                && !Path.HasExtension(httpContext.Request.Path.Value))
            {
                httpContext.Request.Path = "/index.html";
            }

            await this.next.Invoke(httpContext);
        }
    }
}