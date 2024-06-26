﻿namespace MoviesApi.Models
{
    public class Genre
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
