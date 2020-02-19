using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Temp.DataAccess.Data
{
    /// <summary>
    /// Class Role
    /// </summary>
    public class Role
    {
        /// <summary>
        /// primary key role
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// name of role
        /// </summary>
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }
        
        /// <summary>
        /// List user
        /// </summary>
        public ICollection<User> User { get; set; }
    }
}