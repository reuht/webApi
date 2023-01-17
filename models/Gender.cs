namespace Models;

public class Gender
{
    public Guid GenderId { get; set; }
    public string NameGender { get; set; } = null!; //no null 
     public IEnumerable<MovieGender>? MovieGenders {get; set;} 
}