using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class CreateDto
    {
        [Required]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        public string SellerName { get; set; } = string.Empty;
        [Required] 
        public bool Availability { get; set; }
    }
}