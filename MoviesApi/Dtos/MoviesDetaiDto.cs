namespace MoviesApi.Dtos
{
    public class MoviesDetaiDto
    {
        public int Id { get; set; }
  
        public string Title { get; set; }
        public int Year { get; set; }
        public double Rate { get; set; }
  
        public string Storeline { get; set; }
        public byte[] Poster { get; set; }
        public int GenreId { get; set; }
        public String GenreName { get; set; }
    }
}
