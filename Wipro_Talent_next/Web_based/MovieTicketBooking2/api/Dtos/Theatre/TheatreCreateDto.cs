using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Theatre
{
    public class TheatreCreateDto
    {
        [Required]
        public string TheatreName { get; set; } = string.Empty;
        
        [Required]
        public int NumberOfSeats { get; set; }   
    }
}