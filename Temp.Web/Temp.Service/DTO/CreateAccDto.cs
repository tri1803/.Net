using System;

namespace Temp.Service.DTO
{
    /// <summary>
    /// create account model
    /// </summary>
    public class CreateAccDto
    {
        /// <summary>
        /// user name
        /// </summary>
        public string Username { get; set; }
        
        /// <summary>
        /// password
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// confirm password
        /// </summary>
        public string ConfirmPass { get; set; }
        
        /// <summary>
        /// role of account
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// create date account
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Expired date account
        /// </summary>
        public DateTime ExpiredDate { get; set; }

        /// <summary>
        /// type of account
        /// </summary>
        public int Type { get; set; }
    }
}