using Business.Abstract;
using Business.Concrete;
using Business.Repositories;
using DataAccess.Repositories;
using DataAccess.Repositories.EF;
using Microsoft.Extensions.DependencyInjection;

namespace API.Installer.Services
{
    public class InterfaceInstaller     :IServiceInstaller
    {
        public void InstallService(IServiceCollection services)
        {

            services.AddSingleton(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddSingleton(typeof(ISqlRepository<>), typeof(EfSqlRepository<>));
            services.AddSingleton(typeof(IServiceRepository<>), typeof(ServiceRepository<,>));

            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IUserGroupService, UserGroupService>();
            services.AddSingleton<IGenderService, GenderService>();
            
        }
    }
}