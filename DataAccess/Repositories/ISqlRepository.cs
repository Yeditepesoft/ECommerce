using System.Linq;
using Core.Signatures;

namespace DataAccess.Repositories
{
    public interface ISqlRepository<out TQuery>
        where TQuery : class, IBaseQuery, new()
    {

        /// <summary>
        /// T-SQl Select Method with Parameters
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IQueryable<TQuery> Query(string query, params object[] parameters);
    }
}