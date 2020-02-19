using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Temp.DataAccess.Data
{
    public class Sale
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Desc { get; set; }

        public int ProductId { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? Percent { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
