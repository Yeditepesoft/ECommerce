using System.Threading.Tasks;
using Business.Models;
using Business.Repositories;
using Core.Models;

namespace Business.Abstract
{
    public interface IGenderService:IServiceRepository<GenderDto>
    {
         /// <summary>
         /// Gel All Entities by Filter
         /// </summary>
         /// <param name="filter"></param>
         /// <returns></returns>
        Task<PagedList<GendersDto>> GetAllAsync(Filter filter);
    }
}