using System.ComponentModel.DataAnnotations.Schema;
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
    [NotMappedAttribute]
    public virtual string Genders {get; set;}
    public virtual List<MovieGender>? MovieGenders {get; set;}
    public virtual List<UserMovie>? UserMovies {get; set;}

}

