using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DomainLayer.models
{
    public class picture
    {
        public int id { get; set; }
        public byte[] picture1 { get; set; }
        public byte[] picture2 { get; set; }
        public byte[] picture3 { get; set; }
        public byte[] picture4 { get; set; }
       
        public virtual Product product { get; set; }
    }
}
