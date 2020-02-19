using System;
using System.Collections.Generic;
using System.Text;
using Temp.DataAccess.Data;
using Temp.Service.DTO;

namespace Temp.Service.Service
{
    public interface IRoleService
    {
        IEnumerable<RoleDto> GetAll();

        void Save(RoleDto roleDto);

        void Delete(int id);

        RoleDto GetById(int id);

        List<Role> GetAllRole();
    }
}
