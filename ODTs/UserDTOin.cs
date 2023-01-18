namespace backEnd.DTOs;


public class UserDTO {
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Pass { get; set; } = null!;
    public RolDTO Roluser {get;set;}
    public string Identification { get; set; } = null!;
    public string Adress { get; set; } = null!;
}

public enum RolDTO {
    user,
    admin
}

