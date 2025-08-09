using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Show
{
    public class ShowCreateDto
    {
        [Required]
        public int MovieId { get; set; }

        [Required]
        public int TheatreId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PlatinumSeatRate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SilverSeatRate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal GoldSeatRate { get; set; }
    }
}