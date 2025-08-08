using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketBooking
{
    public class Movie
    {
        public string MovieId { get; set; } = string.Empty;

        public string MovieName { get; set; } = string.Empty;

        public string DirectorName { get; set; } = string.Empty;

        public string ProducerName { get; set; } = string.Empty;

        public double Duration { get; set; }

        public string Story { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;

        public string Language { get; set; } = string.Empty;

        public Movie(string MovieName, string DirectorName, string ProducerName, Double Duration, string Story, string Genre, string Language)
        {
            this.MovieName = MovieName;
            this.DirectorName = DirectorName;
            this.ProducerName = ProducerName;
            this.Duration = Duration;
            this.Story = Story;
            this.Genre = Genre;
            this.Language = Language;
            MovieId = MovieName.Substring(0, 2) + ProducerName.Substring(0, 2) + Genre.Substring(0, 2) + Language.Substring(0, 2);
        }

        public void DisplayMovieDetails()
        {
            Console.WriteLine($"{MovieId} - {MovieName} -{ProducerName} - {Duration} - {Story} - {Genre} - {Language}"); 
        }
    }
}