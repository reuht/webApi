namespace Models;

public class UserMovie 
{   
   
    public Guid UserId {get; set;}
    public Guid MovieId {get; set;}
    public DateTime Booking {get; set;}
    public DateTime DataRent {get; set;}
    public DateTime Delivery {get; set;} 
    public User User {get; set;}
    public Movie Movie {get; set;}
}

