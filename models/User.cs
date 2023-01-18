// using System.ComponentModel.DataAnnotations.Schema;
// using System.Text.Json.Serialization;

namespace Models;
public class User
{   
    public Guid UserId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Pass { get; set; } = null!;
    public Rol Roluser {get;set;}
    public string Identification { get; set; } = null!;
    public string Adress { get; set; } = null!;
    public IEnumerable<UserMovie> UserMovies {get; set;}
    
}

public enum Rol {
    user,
    admin
}

