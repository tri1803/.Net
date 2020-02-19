using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Temp.DataAccess.Data
{
    public class Comment
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }

        [Column(TypeName = "ntext")]
        public string Desc { get; set; }

        public Product Product { get; set; }

        public User User { get; set; }
    }
}
