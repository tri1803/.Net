using System.Threading.Tasks;
using Temp.DataAccess.Data;

namespace Temp.Service.BaseService
{
    /// <summary>
    /// interface of unit of work
    /// </summary>
    public interface IUnitofWork
    {
        /// <summary>
        /// role repo
        /// </summary>
        IBaseService<Role> RoleBaseService { get; }
        
        /// <summary>
        /// user repo
        /// </summary>
        IBaseService<User> UserBaseService { get; }

        /// <summary>
        /// Category repo
        /// </summary>
        IBaseService<Category> CategoryBaseService { get; }

        /// <summary>
        /// product repo
        /// </summary>
        IBaseService<Product> ProductBaseService { get; }

        IBaseService<Cart> CartBaseService { get; }

        IBaseService<CartDetail> CartDetailBaseService { get; }

        IBaseService<Comment> CommentBaseService { get; }

        IBaseService<Image> ImageBaseService { get; }

        IBaseService<Nsx> NsxBaseService { get; }

        IBaseService<Sale> SaleBaseService { get; }

        /// <summary>
        /// save
        /// </summary>
        void Save();
        
        /// <summary>
        /// save async
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();
    }
}