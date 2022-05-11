using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DomainLayer.models
{
    public class CartItems
    {
        public int id { set; get; }
        public int quantity { set; get; }
        [ForeignKey("product")]
        public int productId { set; get; }
        [ForeignKey("cartId")]
        public int cartId { get; set; }
        public virtual Cart Cart { set; get; } 
        public virtual Product product { set; get; }
    }
}
