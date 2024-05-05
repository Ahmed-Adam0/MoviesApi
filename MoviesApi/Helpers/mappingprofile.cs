using Microsoft.AspNetCore.Routing.Constraints;

namespace MoviesApi.Helpers
{
    public class mappingprofile:Profile
    {
        public  mappingprofile() 
        {
            CreateMap<Movie, MoviesDetaiDto>();
            CreateMap<MoviesDto, Movie>()
                .ForMember(src => src.Poster, opt => opt.Ignore());

        }
    }
}
