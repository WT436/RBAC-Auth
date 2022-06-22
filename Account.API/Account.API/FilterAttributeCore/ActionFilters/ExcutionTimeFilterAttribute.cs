using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Account.API.FilterAttributeCore.ActionFilters
{
    public class ExcutionTimeFilterAttribute : Attribute,IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.HttpContext.Items.ContainsKey(typeof(SuppressItemKey)))
            {
                var clock = (Stopwatch)context.HttpContext.Items[typeof(StopwatchItemKey)];
                var elapsedMilliseconds = clock.ElapsedMilliseconds;
                //context.Result = new ObjectResult(TimeSpan.FromMilliseconds(elapsedMilliseconds).TotalSeconds);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Items[typeof(StopwatchItemKey)] = Stopwatch.StartNew();
        }
        private class StopwatchItemKey { }
        private class SuppressItemKey { }
    }
}
