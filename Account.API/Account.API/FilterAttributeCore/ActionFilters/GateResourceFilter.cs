using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Reflection;

namespace Account.API.FilterAttributeCore.ActionFilters
{
    public class GateActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var responsesResource = new ResponsesResource();

            try
            {
                context.ExceptionHandled = true;
                HttpResponse response = context.HttpContext.Response;
                response.ContentType = "application/json";

                if (context.Result == null && (context.Exception is Utils.Exceptions.ClientException ce))
                {
                    responsesResource.ErrorCode = ce.errorCode.ToString();

                    responsesResource.Error = true;
                    responsesResource.MessageError = context.Exception.Message;
                    responsesResource.Result = null;
                }
                else
                {
                    responsesResource.Result = JsonConvert.SerializeObject(((ObjectResult)context.Result).Value.ToString());
                }

                // Mã hóa gửi đi
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                context.Result = new ObjectResult(JsonConvert.SerializeObject(responsesResource));
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Giải mã nhận về
        }

        private class ResponsesResource
        {
            public bool Error { get; set; } = false;
            public string ErrorCode { get; set; }
            public string MessageError { get; set; }
            public string Result { get; set; }
        }
    }
}
