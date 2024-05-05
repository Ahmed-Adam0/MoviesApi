using Microsoft.EntityFrameworkCore;
using MoviesApi.Models;

namespace MoviesApi.Servies
{
    public class GenresService : IGenresService
    {
        private readonly ApplicationDbContext _context;

        public GenresService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Genre> add(Genre genre)
        {
            await _context.genres.AddAsync(genre);
            _context.SaveChanges();
            return genre;   
        }

        public Genre delete(Genre genre)
        {
            _context.Remove(genre);
            _context.SaveChanges();
            return genre;
        }

        public async Task<IEnumerable<Genre>> Getall()
        {
           return await _context.genres.OrderBy(g => g.Name).ToListAsync();
        }

        public async Task<Genre> Getbyid(int id)
        {
            return await _context.genres.SingleOrDefaultAsync(g => g.Id == id);
        }

        public Task<bool> isvalidgenre(int id)
        {
            return  _context.genres.AnyAsync(g => g.Id == id);
        }

        public Genre update(Genre genre)
        {
            _context.Update(genre);
            _context.SaveChanges();
            return genre;
        }
    }
}
