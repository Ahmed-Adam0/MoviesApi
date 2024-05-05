namespace MoviesApi.Dtos
{
    public class CreateGenresDto
    {
        [MaxLength(100)]
        public string name { get; set; }
    }
}
