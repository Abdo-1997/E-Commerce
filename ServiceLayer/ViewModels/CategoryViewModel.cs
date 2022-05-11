using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ViewModels
{
    public class CategoryViewModel
    {
        public int id { set; get; }
        [Required(ErrorMessage ="this field is required")]
        [MaxLength(10,ErrorMessage ="max length is 10 and minemum 3 ")]
        [MinLength(2,ErrorMessage ="max length is 10 and minemum 3 ")]
        public string name { get; set; }

    }
}
