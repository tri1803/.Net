using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Temp.DataAccess.Data
{
    /// <summary>
    /// Category
    /// </summary>
    public class Category
    {
        /// <summary>
        /// primary key category
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// name of category
        /// </summary>
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }
        
        /// <summary>
        /// List Product
        /// </summary>
        public ICollection<Product> Products { get; set; }
    }
}