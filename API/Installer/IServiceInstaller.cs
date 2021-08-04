using Microsoft.Extensions.DependencyInjection;

namespace API.Installer
{
    public interface IServiceInstaller
    {
        /// <summary>
        /// Install Service Collection
        /// </summary>
        /// <param name="services"></param>
        void InstallService(IServiceCollection services);
    }
}