using AutoMapper;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.DTOs.UserDtos;

namespace Bosch.Events.UseCases.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile() 
        {
            CreateMap<User,UserDto>();
            CreateMap<InsertUserDto, User>();
            CreateMap<UserDto, User>();
        }
    }
}
