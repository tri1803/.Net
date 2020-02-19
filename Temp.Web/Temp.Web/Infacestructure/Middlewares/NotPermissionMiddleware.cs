using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Temp.Common.Infrastructure;

namespace Temp.Web.Infacestructure.Middlewares
{
    /// <summary>
    /// not permission middleware class
    /// </summary>
    public class NotPermissionMiddleware
    {
        private readonly RequestDelegate _next;
        
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="next"></param>
        public NotPermissionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);
            if (context.Response.StatusCode == StatusCodes.Status403Forbidden && !context.Response.HasStarted)
            {
                context.Request.Path = Constants.Route.AccessDenied;
                await this._next(context);
            }
        }
    }
}