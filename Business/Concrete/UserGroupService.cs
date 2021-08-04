using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Models;
using Business.Repositories;
using Core.Aspects.CacheAspect;
using Core.Extensions;
using Core.Models;
using Core.Plugins.Caching;
using DataAccess.Entities;
using DataAccess.Repositories;

namespace Business.Concrete
{
    public class UserGroupService : ServiceRepository<UserGroup, UserGroupDto>, IUserGroupService
    {
        private readonly IRepository<UserGroup> _repository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;

        public UserGroupService(IRepository<UserGroup> repository, IMapper mapper, ICacheService cacheService) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        [CacheAspect]
        public async Task<PagedList<UserGroupsDto>> GetAllAsync(Filter filter)
            => await Task.Run(() => _repository.AsNoTracking.Filter(filter).ToPagedList<UserGroup, UserGroupsDto>(filter, _mapper));
        

        /*public async Task<PagedList<UserGroupsDto>> GetAllAsync(Filter filter)
        {
            const string key = "UserGroup.GetAll";
            
            if (await _cacheService.AnyAsync(key))
                return await _cacheService.GetAsync<PagedList<UserGroupsDto>>(key);

            var entities = _repository.AsNoTracking.Filter(filter).ToPagedList<UserGroup, UserGroupsDto>(filter, _mapper);

            await _cacheService.SetAsync(key, entities.ToJson());

            return entities;


            //return await Task.Run(() =>_repository.AsNoTracking.Filter(filter).ToPagedList<UserGroup, UserGroupsDto>(filter, _mapper));
        }*/
    }
}