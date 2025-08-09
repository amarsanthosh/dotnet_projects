using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Movie
{
    public class MovieCreateDto
    {
        [Required]
        public string MovieName { get; set; } = string.Empty;
        [Required]
        public string DirectorName { get; set; } = string.Empty;
        [Required]
        public string ProducerName { get; set; } = string.Empty;
        [Required]
        public double Duration { get; set; }
        [Required]
        public string Story { get; set; } = string.Empty;
        [Required]
        public string Genre { get; set; } = string.Empty;
        [Required]
        public string Language { get; set; } = string.Empty;
    }
    
}