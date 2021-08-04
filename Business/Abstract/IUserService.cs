using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;
using Business.Repositories;
using Core.Models;

namespace Business.Abstract
{
    public interface IUserService:IServiceRepository<UserDto>
    {
        Task<PagedList<UsersDto>> GetAllAsync(Filter filter);
    }
}