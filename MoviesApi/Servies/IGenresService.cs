namespace MoviesApi.Servies
{
    public interface IGenresService
    {
        Task<IEnumerable<Genre>> Getall();
        Task<Genre> Getbyid(int id);
        Task<Genre> add(Genre genre);
        Genre update(Genre genre);
        Genre delete(Genre genre); 
        Task<bool> isvalidgenre(int id);    
    }
}
