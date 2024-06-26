﻿namespace MoviesApi.Dtos
{
    public class MoviesDto
    {
        public int Id { get; set; } 
        [MaxLength(2000)]
        public string Title { get; set; }
        public int Year { get; set; }
        public double Rate { get; set; }
        [MaxLength(2500)]
        public string Storeline { get; set; }
        public IFormFile? Poster { get; set; }
        public int GenreId { get; set; }
    }
}
