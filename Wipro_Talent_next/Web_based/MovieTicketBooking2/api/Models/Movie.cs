using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        public string MovieName { get; set; } = string.Empty;

        public string DirectorName { get; set; } = string.Empty;

        public string ProducerName { get; set; } = string.Empty;

        public double Duration { get; set; }

        public string Story { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;

        public string Language { get; set; } = string.Empty;   
    }
}