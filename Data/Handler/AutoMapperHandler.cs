using AppFilm.Net.Models;
using AutoMapper;

namespace AppFilm.Net.Handler;
public class AutoMapperHandler:Profile
{
    public AutoMapperHandler()
    {
        CreateMap<MovieView, Movie>();        ;
        CreateMap<MovieView, Trailers>();
        CreateMap<PeopleView, People>();
    }
}