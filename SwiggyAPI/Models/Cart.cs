using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SwiggyAPI.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public string Img { get; set; }
        public string ProductName { get; set; }

        public string Category { get; set; }
        public int Quantity { get; set; }
        public int price { get; set; }
    }
}
