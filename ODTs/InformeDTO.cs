
namespace backEnd.DTOs; 

public class InformeDTO{

    public Guid UserId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Identification { get; set; } = null!;
    public string Adress { get; set; } = null!;
    
    
}