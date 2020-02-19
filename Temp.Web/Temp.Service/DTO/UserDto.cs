using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Temp.DataAccess.Data;

namespace Temp.Service.DTO
{
    /// <summary>
    /// user view model
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// primary key id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// user name
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public string Username { get; set; }

        /// <summary>
        /// passowrd
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public string Password { get; set; }

        /// <summary>
        /// expired date
        /// </summary>
        public DateTime? ExpiredDate { get; set; }

        /// <summary>
        /// create date
        /// </summary>
        public DateTime? CreateDate { get; set; }

        public int? Type { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public int? Status { get; set; }

        public string Avatar { get; set; }

        /// <summary>
        /// Foreign key RoleId
        /// </summary>
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public Comment Comment { get; set; }

        public Cart Cart { get; set; }
    }
}