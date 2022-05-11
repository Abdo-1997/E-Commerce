using Ecommerce.DomainLayer.models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.ViewModels
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "this field is required")]
        [MaxLength(10, ErrorMessage = "max lingth is 10")]
        [MinLength(3, ErrorMessage = "min length is 3")]
        public string name { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [MaxLength(10, ErrorMessage = "max lingth is 10")]
        [MinLength(3, ErrorMessage = "min length is 3")]
        public string sellername { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public int quantity { get; set; }
       
        [Required(ErrorMessage = "this field is required")]

        public decimal price { get; set; }
        [Required]

        public string description { get; set; }
        [Required]
        public string brandname { set; get; }
        [Required]
        public int maincategoryid { get; set; }
        [Required]
        public int supCategoryid{ set; get; }
        [Required]
        #region pictures
        public IFormFile FormFile1 { set; get; }
        [Required]
        public IFormFile FormFile2 { set; get; }
        [Required]
        public IFormFile FormFile3 { set; get; }
        [Required]
        public IFormFile FormFile4 { set; get; }

      
        #endregion
    }
}
