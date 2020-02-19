using System.Collections.Generic;
using Temp.Service.DTO;

namespace Temp.Service.Service
{
    public interface INsxService
    {
        /// <summary>
        /// get all category
        /// </summary>
        /// <returns></returns>
        IEnumerable<NsxDto> GetAll();

        /// <summary>
        /// create or edit category
        /// </summary>
        /// <param name="categoryDto"></param>
        void Save(NsxDto nsxDto);

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
        NsxDto GetById(int id);
    }
}
