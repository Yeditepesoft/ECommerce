using System.Threading.Tasks;
using Business.Models;
using Business.Repositories;
using Core.Models;

namespace Business.Abstract
{
    public interface IUserGroupService:IServiceRepository<UserGroupDto>
    {
         /// <summary>
         /// Gel All Entities by Filter
         /// </summary>
         /// <param name="filter"></param>
         /// <returns></returns>
        Task<PagedList<UserGroupsDto>> GetAllAsync(Filter filter);
    }
}