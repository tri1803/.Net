using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Temp.Common.Infrastructure;
using Temp.Service.Service;

namespace Temp.Web.Infacestructure.Filters
{
    /// <summary>
    /// extension request filter class
    /// </summary>
    public class ExtensionRequestFilter : ActionFilterAttribute
    {
        
        private readonly IAccountService _accountService;
        
        /// <summary>
        /// extension request filter constructor
        /// </summary>
        /// <param name="accountService"></param>
        public ExtensionRequestFilter( IAccountService accountService)
        {           
            _accountService = accountService;
        }
        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext = context.HttpContext;
            var name = httpContext.User.Identity.Name;
            var account = _accountService.GetAccount(name);
            if (account.ExpiredDate <= DateTime.Now)
            {
                context.Result = new ViewResult{ViewName = "FilterExpired"};
            }
        }
        
        public override void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}