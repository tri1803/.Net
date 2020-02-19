
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Temp.DataAccess.Data;

namespace Temp.Service.DTO
{
    public class CreateUserDto
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public DateTime? ExpiredDate { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? Type { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public int? Status { get; set; }

        public IFormFile Avatar { get; set; }

        public string AvatarPath { get; set; }

        public int RoleId { get; set; }

        public List<Role> Roles { get; set; }
    }
}
