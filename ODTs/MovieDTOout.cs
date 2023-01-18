
using Models;

namespace backEnd.DTOs; 


public class MovieDTOout {
    public Guid MovieId {get; set;}
    public string Title { get; set; }
    public string Image {get; set;}
    public int Total {get; set;}
    public int Rented {get; set;}
    public int Left {get; set;}
     
}

