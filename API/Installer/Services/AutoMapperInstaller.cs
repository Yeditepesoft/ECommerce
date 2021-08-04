using AutoMapper;
using Business.Installer.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace API.Installer.Services
{
    public class AutoMapperInstaller : IServiceInstaller
    {
        public void InstallService(IServiceCollection services)
        {
            services.AddSingleton(
                new MapperConfiguration(x =>
                    x.AddProfile(new AutoMapperProfiles())
                ).CreateMapper());
        }
    }
}