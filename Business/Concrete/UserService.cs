using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Models;
using Business.Repositories;
using Core.Exceptions;
using Core.Extensions;
using Core.Helpers;
using Core.Models;
using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class UserService : ServiceRepository<User, UserDto>, IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;
        public UserService(IRepository<User> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*public async Task<List<UsersDto>> GetAllAsync()
        {
            var entities = await _repository.AsNoTracking
                .Include(x=>x.Gender)
                .Include(x=>x.UserGroup)
                .ToListAsync();
            return _mapper.Map<List<UsersDto>>(entities);
        }

        public async Task<List<UsersDto>> GetAllAsync(Filter filter)
        {
            var entities= await _repository.AsNoTracking.Include(x => x.Gender).Include(x => x.UserGroup)
                .Filter(filter).OrderBy(filter).SkipTake(filter).ToListAsync();

            return _mapper.Map<List<UsersDto>>(entities);

        }*/

        public async Task<PagedList<UsersDto>> GetAllAsync(Filter filter)
        {
            return await Task.Run(() => 
                _repository.AsNoTracking.Include(x => x.Gender).Include(x => x.UserGroup)
                .Filter(filter).ToPagedList<User, UsersDto>(filter, _mapper)
                );
            
        }

        public override async Task<int> InsertAsync(UserDto dto)
        {
            var entity = _mapper.Map<User>(dto);

            HashingHelper.CreatePasswordHash("Password!!",out var passwordHash,out var passwordSalt);
            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;
            await _repository.InsertAsync(entity);
            return entity.Id;
        }

        public override async Task UpdateAsync(int id, UserDto dto)
        {
            var entity = _mapper.Map<User>(dto);
            entity.Id = id;

            var oldEntity = await _repository.GetAsync(id);
            if (oldEntity == null) throw new DbNullException("Old "+nameof(User));
            
            entity.PasswordHash = oldEntity.PasswordHash;
            entity.PasswordSalt = oldEntity.PasswordSalt;
            
            await _repository.UpdateAsync(entity);
        }
    }
}