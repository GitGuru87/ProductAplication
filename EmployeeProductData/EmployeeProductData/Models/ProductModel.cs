using System;
using Dapper;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace EmployeeProductData.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "This field is required")]
        public string Product { get; set; }

        public string Description { get; set; }

        //[DataType(DataType.Currency)]
        //[Range(0, (double)decimal.MaxValue, ErrorMessage = "Please enter a valid price")]
        //public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "This field is required")]
        public DateTime Created { get; set; }
    }
}
