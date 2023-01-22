namespace Models;

public class UserMovie 
{   
    public Guid UserMovieId {get; set;}
    public Guid UserId {get; set;}
    public Guid MovieId {get; set;}
    public DateTime? Booking {get; set;}
    public DateTime? DataRent {get; set;}
    public DateTime? Delivery {get; set;} 
    public DateTime? Trem {get; set;}
    public decimal Rental_value {get; set;}
    public decimal Fine_value {get; set;}
    public int Movies_total {get; set;}
    public User User {get; set;}
    public Movie Movie {get; set;}
}

