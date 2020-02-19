using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Temp.Common.Infrastructure;
using Temp.DataAccess.Data;
using Temp.Service.BaseService;
using Temp.Service.DTO;
using Role = Temp.Common.Infrastructure.Role;

namespace Temp.Service.Service
{
    /// <summary>
    /// Account service
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }
        
        /// <summary>
        /// login
        /// </summary>
        /// <param name="logInDto"></param>
        /// <returns></returns>
        public User LogIn(LogInDto logInDto)
        {
            var account =
                _unitofWork.UserBaseService.ObjectContext.Include(s => s.Role).FirstOrDefault(s => s.Username == logInDto.Username && s.Password == logInDto.Password);
            return account;
        }
        
        /// <summary>
        /// register
        /// </summary>
        /// <param name="accDto"></param>
        public void CreateAccount(CreateAccDto accDto)
        {
            accDto.RoleId = (int)Role.User;
            accDto.CreateDate = DateTime.Now;
            accDto.ExpiredDate = DateTime.Now;
            accDto.Type = (int)UserType.None;
            var user = _mapper.Map<CreateAccDto, User>(accDto);
            _unitofWork.UserBaseService.Add(user);
            _unitofWork.Save();
        }
        
        /// <summary>
        /// check account
        /// </summary>
        /// <param name="accDto"></param>
        /// <returns></returns>
        public bool CheckAccount(CreateAccDto accDto)
        {
            var isExist = _unitofWork.UserBaseService.ObjectContext.Any(s => s.Username.Equals(accDto.Username));
            if (!isExist)
            {
                return true;
            }            
            return false;               
        }
        
        /// <summary>
        /// change password
        /// </summary>
        /// <param name="passDto"></param>
        /// <returns></returns>
        public bool ChangePass(ChangePassDto passDto)
        {
            var user = _unitofWork.UserBaseService.ObjectContext.Include(s => s.Role).FirstOrDefault(s => s.Username == passDto.UserName);
            
            if (user == null) return false;
            var userUpdate = new User
            {
                Username = user.Username,
                Id = user.Id,
                Password = passDto.Password,
                RoleId = user.Id
            };
            _unitofWork.UserBaseService.Update(userUpdate);
            _unitofWork.Save();
            return true;
        }
        
        /// <summary>
        /// check password
        /// </summary>
        /// <param name="passDto"></param>
        /// <returns></returns>
        public bool CheckPass(ChangePassDto passDto)
        {
            var user = _unitofWork.UserBaseService.Get(s => s.Username == passDto.UserName);
            if (user != null && user.Password != passDto.CurrentPass)
            {
                return false;
            }

            return true;
        }
        
        /// <summary>
        /// get account by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public User GetAccount(string name)
        {
            return _unitofWork.UserBaseService.ObjectContext.FirstOrDefault(s => s.Username == name);
        }
        
        /// <summary>
        /// request expired date
        /// </summary>
        /// <param name="user"></param>
        public void RequestExpired(User user)
        {
            user.Type = (int)UserType.Processing;
            _unitofWork.Save();
        }
    }
}