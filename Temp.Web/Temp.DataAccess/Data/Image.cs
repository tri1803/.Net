using System;
using System.Collections.Generic;
using System.Text;

namespace Temp.DataAccess.Data
{
    public class Image
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public string Image4 { get; set; }

        public Product Product { get; set; }
    }
}
