#region
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Utils.Auth;
using Utils.Cache;
using Utils.Email;
using Utils.WriteLogExtention.Application;

#endregion

namespace Account.API.InstallStartup.InstallerServices
{
    public class DIInstall : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            // Scoped: Kiểu 1:1 Service bị hủy thì nó sẽ hủy toàn bộ,
            // 1 Scoped sinh ra thì tất cả những yêu cầu từ phía 1 HTTP nhưng dùng nhiều view or controller
            // Singleton : Khởi tạo 1 lần cho cả hệ thống. Chỉ 1 object dùng chung cho hệ thống
            // Transient : Khởi tạo object mỗn lần khi được yêu cầu - riêng lẻ

            #region default - common
            services.AddTransient<IJwtHandler, JwtHandler>();
            services.AddTransient<IMailService, MailService>();
            services.AddSingleton<ICacheBase, CacheMemoryHelper>();
            services.AddSingleton<ILog4NetManager, Log4NetManager>();
            #endregion
          
        }
    }

}
