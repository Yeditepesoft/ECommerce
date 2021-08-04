using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace API.Installer
{
    public interface IConfigureInstaller
    {
        /// <summary>
        /// Install Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        void InstallConfigure(IApplicationBuilder app, IWebHostEnvironment env);
    }
}