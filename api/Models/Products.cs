using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{

    public class Products
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string SellerName { get; set; } = string.Empty; 
        public bool Availability { get; set; }


    }
}