using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExamMVCApp.Models
{
    public class Product
    {
        [Key]
        public int ProductId { set; get; }

        [Required(ErrorMessage ="Product Name cannot be Empty")]
        [DataType(DataType.Text)]
        [StringLength(20,ErrorMessage ="The {0} length cannot more than {1} characters")]
        public string ProductName { set; get; }

        [Required(ErrorMessage = "Rate cannot be Empty")]
        [Range(1,100,ErrorMessage ="Rate must be inbetween 1 to 100")]
        public decimal Rate { set; get; }

        [Required(ErrorMessage = "Description cannot be Empty")]
        [DataType(DataType.Text)]
        public string Description { set; get; }

        [Required(ErrorMessage = "Category Name cannot be Empty")]
        [DataType(DataType.Text)]
        public string CategoryName { set; get; }
    }
}