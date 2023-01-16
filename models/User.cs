namespace Models;
// using System.ComponentModel.DataAnnotations; 
// using System.Text.Json;
using System.Text.Json.Serialization;
public class User
{   
    
    public Guid UserId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Pass { get; set; } = null!;
    public Rol Roluser {get;set;}
    public string Identification { get; set; } = null!;
    public string Adress { get; set; } = null!;
    public int Metric { get; set; }
    [JsonIgnore]
    public ICollection<UserMovie> UserMovies {get; set;}
    
}

public enum Rol {
    user,
    admin
}

