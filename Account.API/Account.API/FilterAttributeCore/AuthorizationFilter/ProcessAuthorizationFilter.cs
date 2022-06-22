using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Account.API.FilterAttributeCore.AuthorizationFilter
{
    /// <summary>
    /// Xác thực tài nguyên người dùng có thể truy cập.
    /// Cấp quyền cho người dùng
    /// </summary>
    public class ProcessAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
           
        }
    }
}
