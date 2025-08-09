using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Show
    {
        public int ShowId { get; set; }
        public int MovieId { get; set; }
        public int TheatreId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal PlatinumSeatRate { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal SilverSeatRate { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal GoldSeatRate { get; set; }
    }
}