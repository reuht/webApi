using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace Models;

public class Movie
{   
   
    public Guid MovieId { get; set; }
    public string Title { get; set; }
    public string Image {get; set;}
    public string Duration { get; set; }
    public string Date { get; set; }
    public string Director { get; set; }
    public string Actors { get; set; }
    public float Qualification { get; set;}
    [JsonIgnore]
    public IEnumerable<MovieGender>? MovieGenders {get; set;}
    [JsonIgnore]
    public IEnumerable<UserMovie>? UserMovies {get; set;}

}

