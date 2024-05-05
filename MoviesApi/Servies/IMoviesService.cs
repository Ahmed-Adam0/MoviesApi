namespace MoviesApi.Servies
{
    public interface IMoviesService
    {
        Task<IEnumerable<Movie>> GetallMoviesAsync();
        Task<Movie> getbyid(int id);
        Task<Movie> postasync(Movie movie);
        Movie update(Movie movie);
        Movie delete(Movie movie);
    }
}
