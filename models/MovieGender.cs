
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
namespace Models;

public class MovieGender {

    public int Id {get; set;}
    public Guid MovieId {get; set;}
    public Guid GenderId {get; set;}
    public Movie Movie {get; set;}
    public Gender Gender {get; set;}
   
}