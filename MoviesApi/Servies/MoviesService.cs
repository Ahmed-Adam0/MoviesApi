using MoviesApi.Models;

namespace MoviesApi.Servies
{
    public class MoviesService : IMoviesService
    {
        private readonly ApplicationDbContext _context;

        public MoviesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Movie delete(Movie movie)
        {
            _context.Remove(movie);
            _context.SaveChanges();
            return movie;
        }

        public async Task<IEnumerable<Movie>> GetallMoviesAsync()
        {
            return await _context.movies
            .OrderByDescending(o => o.Rate).Include(m => m.Genre)
            .ToListAsync();
        }

        public async Task<Movie> getbyid(int id)
        {
            return await _context.movies.Include(m => m.Genre).SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Movie> postasync(Movie movie)
        {
            await _context.AddAsync(movie);
            _context.SaveChanges();
            return movie;
        }
        public Movie update(Movie movie)
        {
            _context.Update(movie);
            _context.SaveChanges();
            return movie;
        }
    }
}
