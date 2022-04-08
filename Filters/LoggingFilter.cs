using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAssiginment.Filters
{
    public class LoggingFilter : Attribute, IActionFilter
    {
        private readonly ILogger<LoggingFilter> logger;

        public LoggingFilter(ILogger<LoggingFilter> logger)
        {
            this.logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation("Request Time for {0} {1}", context.HttpContext.Request.Host, DateTime.Now);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation("Response Time for {0} {1}", context.HttpContext.Request.Host, DateTime.Now);
        }
    }
}
