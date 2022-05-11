using Ecommerce.DomainLayer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ViewModels
{
    public class CartViewModel
    {
        public int quantity { set; get; }
      public  IEnumerable<CartItems> Products { set; get; }
    }
}
