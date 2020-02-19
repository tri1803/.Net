using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Temp.Service.BaseService
{
    /// <summary>
    /// Interface of base service generic
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseService<T> where T : class
    {
        /// <summary>
        /// get all
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
        
        /// <summary>
        /// get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="allowTracking"></param>
        /// <returns></returns>
        T GetById(int id, bool allowTracking = true);
        
        /// <summary>
        /// create entity
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);
        
        /// <summary>
        /// delete entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
        
        /// <summary>
        /// edit entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
        
        /// <summary>
        /// get entity has expression
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> where);
        
        /// <summary>
        /// get many
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IEnumerable<T> GetMany(Func<T, bool> where);
        
        /// <summary>
        /// object context
        /// </summary>
        IQueryable<T> ObjectContext { get; set; }
        
        /// <summary>
        /// get all async
        /// </summary>
        /// <param name="allowTracking"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync(bool allowTracking = true);
        
        /// <summary>
        /// get async entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="allowTracking"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id, bool allowTracking = true);
    }
}