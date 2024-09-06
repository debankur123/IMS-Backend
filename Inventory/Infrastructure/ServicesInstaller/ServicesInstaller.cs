using Inventory.AppCode;
using Inventory.AppCode.Helper;
using Inventory.Repository.IService;
using Inventory.Repository.Service;

namespace Inventory.Infrastructure.ServicesInstaller
{
    public interface IInstaller
    {
        void InstallerServices(IServiceCollection services, IConfiguration configuration);
    }
    public class ServicesInstaller: IInstaller
    {
        public void InstallerServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ITokenService, TokenService>();
            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<IMailHelper, MailHelper>();
            services.AddSingleton<ISessionHelper, SessionHelper>();
            
        }
    }
}
