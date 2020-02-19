using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Temp.Common.Infrastructure;
using Temp.DataAccess.Data;
using Temp.Service.BaseService;
using Temp.Service.DTO;

namespace Temp.Service.Service
{
    /// <summary>
    /// user service class
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        
        /// <summary>
        /// userservice constructor
        /// </summary>
        public UserService(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }
        /// <summary>
        /// get all user
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserDto> GetAll()
        {
            var user = _unitofWork.UserBaseService.ObjectContext.Include(s => s.Role);
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(user);
        }
        
        /// <summary>
        /// create or edit user
        /// </summary>
        /// <param name="userDto"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Save(CreateUserDto userDto, IFormFile Avatar)
        {
            var filename = ContentDispositionHeaderValue.Parse(Avatar.ContentDisposition).FileName.Trim('"');
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", Avatar.FileName);
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                Avatar.CopyToAsync(stream);
            }
            if (userDto.Id <= 0)
            {               
                var user = _mapper.Map<CreateUserDto, User>(userDto);
                user.CreateDate = DateTime.Now;
                user.ExpiredDate = DateTime.Now;
                user.Status = 0;
                user.Type = 0;
                user.Avatar = filename;
                _unitofWork.UserBaseService.Add(user);
                _unitofWork.Save();
            }
            else
            {

                var user = _mapper.Map<CreateUserDto, User>(userDto);
                user.CreateDate = DateTime.Now;
                user.ExpiredDate = DateTime.Now;
                user.Status = 0;
                user.Type = 0;
                user.Avatar = filename;
                _unitofWork.UserBaseService.Update(user);
                _unitofWork.Save();
            }
        }
        
        /// <summary>
        /// delete user
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(int id)
        {
            var user = _unitofWork.UserBaseService.GetById(id);
            _unitofWork.UserBaseService.Delete(user);
            _unitofWork.Save();
        }
        
        /// <summary>
        /// approve request expired for user
        /// </summary>
        /// <param name="user"></param>
        public void ApproveRequestExpired(User user)
        {
            user.Type = (int) UserType.None;
            user.ExpiredDate = DateTime.Now.AddDays(1);
            _unitofWork.Save();
        }
        
        /// <summary>
        /// reject request expired for user
        /// </summary>
        /// <param name="user"></param>
        public void RejectRequestExpired(User user)
        {
            user.Type = (int) UserType.None;
            _unitofWork.Save();
        }
        
        /// <summary>
        /// get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetById(int id)
        {
            var user = _unitofWork.UserBaseService.GetById(id);
            return user;
        }

        public CreateUserDto GetUserEditById(int id)
        {
            var user = _unitofWork.UserBaseService.GetById(id);
            var userDto = new CreateUserDto
            {
                Id = user.Id,
                UserName = user.Username,
                Address = user.Address,
                CreateDate = user.CreateDate,
                ExpiredDate = user.ExpiredDate,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Phone = user.Phone,
                RoleId = user.RoleId,
                Status = user.Status,
                Type = user.Type,
                AvatarPath = user.Avatar
            };           
            return userDto;
        }
    }
}