using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Temp.DataAccess.Data
{
    public class Nsx
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
