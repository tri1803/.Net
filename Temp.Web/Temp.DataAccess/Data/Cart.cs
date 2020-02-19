using System;
using System.Collections.Generic;
using System.Text;

namespace Temp.DataAccess.Data
{
    public class Cart
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int? TotalMoney { get; set; }

        public User User { get; set; }

        public ICollection<CartDetail> CartDetails { get; set; }
    }
}
