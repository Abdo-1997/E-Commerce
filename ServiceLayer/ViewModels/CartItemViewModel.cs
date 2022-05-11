using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ViewModels
{
    public class CartItemViewModel
    {

        public int productid { get; set; }
        public decimal productPrice { get; set; }
        public string productname { get; set; }
        public int cartitemid { get; set; }
        public int productquantity { get; set; }
        public byte[] picture { set; get; } 
    }
}
