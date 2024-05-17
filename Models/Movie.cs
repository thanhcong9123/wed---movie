using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppFilm.Net.Models;
public partial class Movie
{
    [Key]
    public int Id {get;set;} 
    public string? NameEL {get;set;}
    public string? NameVN {get;set;}
    public DateTime ReleaseDate { get; set; }
    public string? Content { get; set; }
    public float Point {get;set;}
    public string? Image {get;set;}
    public string? Background {get;set;}
    public List<PeopleDirectorConnMovie>? PeopleDirectorConnMovies {get;set;}
    public List<PeoplePerformerConnMovie>? PeoplePerformerConnMovies {get;set;}
    public List<NationConnMovie>? NationConnMovies {get;set;}
    public List<GenreConnMovie>? GenreConnMovies {get;set;}
    public List<TrailersConnMovie>? TrailersConnMovies {get;set;}
    public List<SeasonsConnMovie>? SeasonsConnMovies {get;set;}
    public List<CollectionMovies>? collectionMovies {get;set;}
    [ForeignKey("Years")]
    public int IdYears{ get; set; }
    public Years Years { get; set; }
    [ForeignKey("MovieType")]
    public int IdMovieType { get; set; }
    public MovieType MovieType { get; set; }

}
