namespace Models;

public class Movie
{   
   
    public Guid MovieId { get; set; }
    public string Title { get; set; }
    public string image {get; set;}
    public string Duration { get; set; }
    public string Date { get; set; }
    public string Director { get; set; }
    public string Actors { get; set; }
    public float Qualification { get; set;}
    public int units { get; set; }
    public List<MovieGender> MovieGenders {get; set;}
    public List<UserMovie> UserMovies {get; set;}

}