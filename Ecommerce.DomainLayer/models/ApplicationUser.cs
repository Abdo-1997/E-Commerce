//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DomainLayer.models
{
    public class ApplicationUser:IdentityUser
    {
        public byte[] profilepic { set; get; }
        [ForeignKey("cart")]
        public int? cartid { set; get; }
        public virtual Cart cart { set; get; }

    }
}
