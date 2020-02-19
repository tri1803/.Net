using System.Collections.Generic;
using Temp.DataAccess.Data;
using Temp.Service.DTO;

namespace Temp.Service.Service
{
    /// <summary>
    /// interface of categoryservice
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// get all category
        /// </summary>
        /// <returns></returns>
        IEnumerable<CategoryDto> GetAll();
        
        /// <summary>
        /// create or edit category
        /// </summary>
        /// <param name="categoryDto"></param>
        void Save(CategoryDto categoryDto); 
        
        /// <summary>
        /// delete category
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
        
        /// <summary>
        /// get category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CategoryDto GetById(int id);
            
        
    }
}