using AutoMapper;
using Temp.DataAccess.Data;
using Temp.Service.DTO;

namespace Temp.Service.Mapper
{
    public class RoleMapping : Profile
    {
        public RoleMapping()
        {
            CreateMap<Role, RoleDto>();

            CreateMap<RoleDto, Role>();
        }
    }
}
