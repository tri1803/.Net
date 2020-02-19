using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using Temp.DataAccess.Data;
using Temp.Service.BaseService;
using Temp.Service.DTO;
using Microsoft.EntityFrameworkCore;

namespace Temp.Service.Service
{
    public class RoleService : IRoleService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public RoleService(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            var role = _unitofWork.RoleBaseService.GetById(id);
            _unitofWork.RoleBaseService.Delete(role);
            _unitofWork.Save();
        }

        public IEnumerable<RoleDto> GetAll()
        {
            var roles = _unitofWork.RoleBaseService.GetAll();
            return _mapper.Map<IEnumerable<Role>, IEnumerable<RoleDto>>(roles);
        }

        public List<Role> GetAllRole()
        {
            return _unitofWork.RoleBaseService.GetAll().ToList();
        }

        public RoleDto GetById(int id)
        {
            var role = _unitofWork.RoleBaseService.GetById(id);
            return _mapper.Map<Role, RoleDto>(role);
        }

        public void Save(RoleDto roleDto)
        {
            if (roleDto.Id <= 0)
            {
                var role = _mapper.Map<RoleDto, Role>(roleDto);
                _unitofWork.RoleBaseService.Add(role);
                _unitofWork.Save();
            }
            else
            {
                var role = _mapper.Map<RoleDto, Role>(roleDto);
                _unitofWork.RoleBaseService.Update(role);
                _unitofWork.Save();
            }
        }
    }
}
