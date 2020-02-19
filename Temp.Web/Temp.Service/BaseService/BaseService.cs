using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Temp.Service.BaseService
{
    /// <summary>
    /// Class base service implement IBaseService
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseService<T> : IBaseService<T> where T  : class    
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public BaseService(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
            ObjectContext = _dbSet;
        }
        
        /// <summary>
        /// get all 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
        
        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="allowTracking"></param>
        /// <returns></returns>
        public T GetById(int id, bool allowTracking = true)
        {
            return _dbSet.Find(id);
        }
        
        /// <summary>
        /// create entity
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        
        /// <summary>
        /// delete entity
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        
        /// <summary>
        /// edit entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
        }
        
        /// <summary>
        /// get entity has expression
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public T Get(Expression<Func<T, bool>> @where)
        {
            return _dbSet.Where(where).FirstOrDefault();
        }
        
        /// <summary>
        /// get many entity has expresstion
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<T> GetMany(Func<T, bool> @where)
        {
            return _dbSet.AsEnumerable().Where(where);
        }

        public IQueryable<T> ObjectContext { get; set; }
        
        /// <summary>
        /// get all async 
        /// </summary>
        /// <param name="allowTracking"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IEnumerable<T>> GetAllAsync(bool allowTracking = true)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// get async entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="allowTracking"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<T> GetByIdAsync(int id, bool allowTracking = true)
        {
            throw new NotImplementedException();
        }
    }
}