namespace Models;

public class Gender
{
    public Guid GenderId { get; set; }
    public string NameGender { get; set; } = null!; //no null 
     public IEnumerable<MovieGender>? MovieGenders {get; set;} 
}


// 0c5c0290-dda9-4743-99c2-7722de2a5cb9 gender
// 23d9c211-fa3e-45c3-b5d4-d6c7be82e896 Movie
