namespace Models; 

public class Stock {
    
    public Guid MovieId {get; set;}
    public int Total {get; set;}
    public int Left {get; set;}
    public int Rented {get; set;}
    public Movie Movie {get; set;}
}