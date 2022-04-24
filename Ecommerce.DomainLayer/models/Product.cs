using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.DomainLayer.models
{
    public class Product
    {
        public int id { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(3)]
        public string name { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(3)]
        public string sellername { get; set; } 
        [Required]
        [MaxLength(10)]
        [MinLength(3)]
        public string brandname { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,4)")]

        public decimal price { get; set; }
        [Required]

        public string description { get; set; }
        public string gender { get; set; }


        [ForeignKey("maincats")]
        public int? maincategoryid { get; set; }

        [ForeignKey("supcats")]

        public int? supcategoryid { set; get; }
        [ForeignKey("pictures")]
         public int? picturesid { set; get; }
         public virtual picture pictures { set; get; }
         public virtual maincat maincat{ set; get; } 
         public virtual supcat supcat { set; get; }
         

    }
}
