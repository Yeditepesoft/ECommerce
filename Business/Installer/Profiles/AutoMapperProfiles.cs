using AutoMapper;
using Business.Models;
using DataAccess.Entities;

namespace Business.Installer.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            Mapping();
        }

        private void Mapping()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UsersDto>()
                .ForMember(d => d.FullName, o => o.MapFrom(x => x.FirstName + " " + x.LastName))
                .ForMember(d=>d.UserGroup,o=>o.MapFrom(x=>x.UserGroup.Description))
                .ForMember(d=>d.Gender,o=>o.MapFrom(x=>x.Gender.Description));


            CreateMap<UserGroup, UserGroupDto>().ReverseMap();
            CreateMap<UserGroup, UserGroupsDto>();

            CreateMap<Gender, GenderDto>().ReverseMap();
            CreateMap<Gender, GendersDto>();
        }
    }
}