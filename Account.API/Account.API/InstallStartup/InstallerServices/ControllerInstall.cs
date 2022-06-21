using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System.Net;
using System.Text.Json.Serialization;
using Account.API.FilterAttributeCore.AuthorizationFilter;
using Account.API.FilterAttributeCore.ResourceFilters;
using Account.API.FilterAttributeCore.ActionFilters;
using Account.API.FilterAttributeCore.ExceptionFilter;

namespace Account.API.InstallStartup.InstallerServices
{
    public class ControllerInstall : IInstaller
    {

        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ForwardedHeadersOptions>(op =>
            {

                op.KnownProxies.Add(IPAddress.Parse("You"));
            });
           // services.AddRouting(options => options.LowercaseUrls = true);
            services.AddControllers(op =>
            {
                //AuthorizationFilter
                op.Filters.Add(new ProcessAuthenticationFilter());
                op.Filters.Add(new ProcessAuthorizationFilter());
                //ResourceFilters
                op.Filters.Add(new IloggingResourceFilter());
                //op.Filters.Add(new CacheResourceFilter());
                //ActionFilters
                op.Filters.Add(new ValidationFilterAttribute());
                op.Filters.Add(new ExcutionTimeFilterAttribute());
                op.Filters.Add(new ModelValidationFilterAttribute());
                op.Filters.Add(new GetAccountIdActionFilter());
                //ExceptionFilter
                op.Filters.Add(new ProcessExceptionFilterAttribute());
            });

            services.AddControllers().AddJsonOptions(x =>
                   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
        }
    }
}
