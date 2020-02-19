using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Temp.DataAccess.Data;
using Temp.Service.BaseService;
using Temp.Service.DTO;

namespace Temp.Service.Service
{
    public class NsxService : INsxService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public NsxService(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            var nsx = _unitofWork.NsxBaseService.GetById(id);
            _unitofWork.NsxBaseService.Delete(nsx);
            _unitofWork.Save();
        }

        public IEnumerable<NsxDto> GetAll()
        {
            var nsx = _unitofWork.NsxBaseService.GetAll();
            return _mapper.Map<IEnumerable<Nsx>, IEnumerable<NsxDto>>(nsx);
        }

        public NsxDto GetById(int id)
        {
            var nsx = _unitofWork.NsxBaseService.GetById(id);
            return _mapper.Map<Nsx, NsxDto>(nsx);
        }

        public void Save(NsxDto nsxDto)
        {
            if (nsxDto.Id <= 0)
            {
                var nsx = _mapper.Map<NsxDto, Nsx>(nsxDto);
                _unitofWork.NsxBaseService.Add(nsx);
                _unitofWork.Save();
            }
            else
            {
                var nsx = _mapper.Map<NsxDto, Nsx>(nsxDto);
                _unitofWork.NsxBaseService.Update(nsx);
                _unitofWork.Save();
            }
        }
    }
}
