using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DomainLayer.models
{
    public class maincat
    {
        public int id { get; set; }
        public string name { get; set; }

        public virtual IEnumerable<Product> products { set; get; }
    }
}
