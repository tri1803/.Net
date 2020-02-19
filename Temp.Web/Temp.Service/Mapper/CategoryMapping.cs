using AutoMapper;
using Temp.DataAccess.Data;
using Temp.Service.DTO;

namespace Temp.Service.Mapper
{
    /// <summary>
    /// Category mapper
    /// </summary>
    public class CategoryMapping : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public CategoryMapping()
        {
            //view model => entities
            CreateMap<CategoryDto, Category>();
            
            //view model => entities
            CreateMap<Category, CategoryDto>();
        }
    }
}