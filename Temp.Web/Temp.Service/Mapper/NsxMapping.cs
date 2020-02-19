using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Temp.DataAccess.Data;
using Temp.Service.DTO;

namespace Temp.Service.Mapper
{
    public class NsxMapping : Profile
    {
        public NsxMapping()
        {
            CreateMap<Nsx, NsxDto>();

            CreateMap<NsxDto, Nsx>();
        }
    }
}
