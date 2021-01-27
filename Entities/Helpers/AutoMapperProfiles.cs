using AutoMapper;
using Core.Entities.Concrete;
using Entities.Dtos;

namespace Entities.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
