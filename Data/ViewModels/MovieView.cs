using System.ComponentModel.DataAnnotations;

namespace AppFilm.Net.Models;
public class MovieView
{
    public string? NameEL {get;set;}
    public string? NameVN {get;set;}
    public DateTime ReleaseDate { get; set; }
    public string? Content { get; set; }
    public float Point {get;set;}
    public string? Image {get;set;}
    public string? Background {get;set;}
    public int IdMovieType {get;set;}
    public int IdYears {get;set;}
    public int Episodes{get;set;}
    public string? FileName {get;set;}
    public List<Nation>? Nation {get;set;}
    public List<Genre>? Genres{get;set;}
    public List<int>? PeoplePerformer{get;set;}
    public List<int>? PeopleDirector{get;set;}
    public List<Trailers>? Trailers{get;set;}

}