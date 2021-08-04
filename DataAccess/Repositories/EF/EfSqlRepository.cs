using System.Linq;
using Core.Signatures;
using DataAccess.Contexts.EF;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.EF
{
    public class EfSqlRepository<TQuery> : ISqlRepository<TQuery>
        where TQuery : class, IBaseQuery, new()
    {
        private readonly DbSet<TQuery> _entities;

        public EfSqlRepository(ECommerceContext context)
        {
            _entities = context.Set<TQuery>();
        }

        public IQueryable<TQuery> Query(string query, params object[] parameters)
            => _entities.FromSqlRaw(query, parameters);
    }
}