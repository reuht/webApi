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
    public bool SoldOut {get; set;}
    public Gender Gender {get; set;}
    public float Qualification { get; set;}
    public decimal Rental_price {get; set;}
    [JsonIgnore]
    public Stock Stock {get; set;}
    [JsonIgnore]
    public IEnumerable<UserMovie> UserMovies {get; set;}
}

public enum Gender 
{
    Accion,
    Aventura,
    CienciaFiccion,
    Comedia,
    Fantasia,
    Musical,
    Suspenso,
    Terror,
    Drama,
    NoFiccion

}