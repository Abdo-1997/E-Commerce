using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DomainLayer.models
{
    public class Cart
    {
        [Key]
        public int id { get; set; }
      
        public virtual ApplicationUser user { get; set; }
        public virtual IEnumerable<CartItems> cartItems { set; get; }
    }
}
