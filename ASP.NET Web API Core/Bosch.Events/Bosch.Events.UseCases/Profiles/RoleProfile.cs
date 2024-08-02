using AutoMapper;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.DTOs.RoleDtos;

namespace Bosch.Events.UseCases.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>();
            CreateMap<InsertRoleDto, Role>();
        }
    }
}
