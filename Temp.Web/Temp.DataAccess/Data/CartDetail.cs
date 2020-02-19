using System;
using System.Collections.Generic;
using System.Text;

namespace Temp.DataAccess.Data
{
    public class CartDetail
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int? Amount { get; set; }

        public int? Price { get; set; }

        public Product Product { get; set; }

        public int CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
