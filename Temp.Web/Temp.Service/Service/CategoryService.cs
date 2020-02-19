using System.Collections.Generic;
using AutoMapper;
using Temp.DataAccess.Data;
using Temp.Service.BaseService;
using Temp.Service.DTO;

namespace Temp.Service.Service
{
    /// <summary>
    /// category service
    /// </summary>
    public class CategoryService : ICategoryService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// category service constructor
        /// </summary>
        /// <param name="unitofWork"></param>
        /// <param name="mapper"></param>
        public CategoryService(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }
        
        /// <summary>
        /// get all category
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CategoryDto> GetAll()
        {
            var categories = _unitofWork.CategoryBaseService.GetAll();
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);
        }
        
        /// <summary>
        /// create or edit category
        /// </summary>
        /// <param name="categoryDto"></param>
        public void Save(CategoryDto categoryDto)
        {
            if (categoryDto.Id <= 0)
            {
                var cate = _mapper.Map<CategoryDto, Category>(categoryDto);
                _unitofWork.CategoryBaseService.Add(cate);
                _unitofWork.Save();
            }
            else
            {
                var cate = _mapper.Map<CategoryDto, Category>(categoryDto);
                _unitofWork.CategoryBaseService.Update(cate);
                _unitofWork.Save();
            }
        }
        
        /// <summary>
        /// delete category
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var cate = _unitofWork.CategoryBaseService.GetById(id);
            _unitofWork.CategoryBaseService.Delete(cate);
            _unitofWork.Save();
        }
        
        /// <summary>
        /// get category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CategoryDto GetById(int id)
        {
            var cate = _unitofWork.CategoryBaseService.GetById(id);
            return _mapper.Map<Category, CategoryDto>(cate);
        }
    }
}