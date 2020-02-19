using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Temp.Common.Infrastructure;

namespace Temp.Web.Infacestructure.Middlewares
{
    /// <summary>
    /// not found middleware
    /// </summary>
    public class NotFoundMiddleware
    {
        private readonly RequestDelegate _next;
        
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="next"></param>
        public NotFoundMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        /// <summary>
        /// invoke function
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            await _next(context);
            if (context.Response.StatusCode == StatusCodes.Status404NotFound && !context.Response.HasStarted)
            {
                context.Request.Path = Constants.Route.NotFound;
                await this._next(context);
            }
        }
    }

    public static class NotFoundMiddlewareExtensions
    {
        public static IApplicationBuilder UseNotFound(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NotFoundMiddleware>();
        }
    }
 }