using Ecommerce.DomainLayer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ViewModels
{
    public class ProductViewModel
    {
        public int id { get; set; }

      
        public string name { get; set; }
     
       // public string sellername { get; set; }
     
        public int quantity { get; set; }
      

        public decimal price { get; set; }
    
      //  public string description { get; set; }


        
        public int? maincategoryid { get; set; }

       

    //   public int? supcategoryid { set; get; }
        
        public picture pictures { set; get; }
       // public maincat maincat { set; get; }
      //  public IEnumerable<supcat> supcats { set; get; }
    }
}
