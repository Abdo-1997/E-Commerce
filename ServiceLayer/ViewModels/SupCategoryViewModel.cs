using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ViewModels
{
    public class SupCategoryViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage ="this Field Is Required ")]
        public string name { get; set; }
    
    }
}
