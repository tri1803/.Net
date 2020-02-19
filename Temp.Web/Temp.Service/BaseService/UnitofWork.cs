using System.Threading.Tasks;
using Temp.DataAccess.Data;

namespace Temp.Service.BaseService
{
    /// <summary>
    /// Unit of Work
    /// </summary>
    public class UnitofWork : IUnitofWork
    {
        //region inject field variables
        private IBaseService<Role> _roleBaseService;
        private IBaseService<User> _userBaseService;
        private IBaseService<Category> _cateBaseService;
        private IBaseService<Product> _productBaseService;
        private IBaseService<Cart> _cartBaseService;
        private IBaseService<CartDetail> _cartDetailBaseService;
        private IBaseService<Comment> _commentBaseService;
        private IBaseService<Image> _ImageBaseService;
        private IBaseService<Nsx> _NsxBaseService;
        private IBaseService<Sale> _saleBaseService;

        private readonly DataContext _dataContext;

        public UnitofWork(DataContext dataContext) => _dataContext = dataContext;

        /// <summary>
        /// Role repo
        /// </summary>
        public IBaseService<Role> RoleBaseService => _roleBaseService =
                    _roleBaseService ?? new BaseService<Role>(_dataContext);

        /// <summary>
        /// User repo
        /// </summary>
        public IBaseService<User> UserBaseService => _userBaseService =
                    _userBaseService ?? new BaseService<User>(_dataContext);

        /// <summary>
        /// Category repo
        /// </summary>
        public IBaseService<Category> CategoryBaseService => _cateBaseService =
                _cateBaseService ?? new BaseService<Category>(_dataContext);

        /// <summary>
        /// product repo
        /// </summary>
        public IBaseService<Product> ProductBaseService => _productBaseService =
                _productBaseService ?? new BaseService<Product>(_dataContext);

        public IBaseService<Cart> CartBaseService => _cartBaseService =
                    _cartBaseService ?? new BaseService<Cart>(_dataContext);

        public IBaseService<CartDetail> CartDetailBaseService => _cartDetailBaseService =
                    _cartDetailBaseService ?? new BaseService<CartDetail>(_dataContext);

        public IBaseService<Comment> CommentBaseService => _commentBaseService =
                    _commentBaseService ?? new BaseService<Comment>(_dataContext);

        public IBaseService<Image> ImageBaseService => _ImageBaseService =
                    _ImageBaseService ?? new BaseService<Image>(_dataContext);

        public IBaseService<Nsx> NsxBaseService => _NsxBaseService =
                    _NsxBaseService ?? new BaseService<Nsx>(_dataContext);

        public IBaseService<Sale> SaleBaseService => _saleBaseService =
                    _saleBaseService ?? new BaseService<Sale>(_dataContext);

        /// <summary>
        /// save change
        /// </summary>
        public void Save() => _dataContext.SaveChanges();

        /// <summary>
        /// save change async
        /// </summary>
        /// <returns></returns>
        public async Task SaveAsync() => await _dataContext.SaveChangesAsync();
    }
}