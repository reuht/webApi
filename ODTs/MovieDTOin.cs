
namespace backEnd.DTOs; 

public class MovieDTOin {
    
    public string Title { get; set; }
    public string Image {get; set;}
    public string Duration { get; set; }
    public string Date { get; set; }
    public string Director { get; set; }
    public string Actors { get; set; }
    public float Qualification {get; set;}
    public GenderODT Gender {get; set;}
    
}

public enum GenderODT 
{
    Accion,
    Aventura,
    CienciaFiccion,
    Comedia,
    Fantasia,
    Musical,
    Suspenso,
    Terror,
    Drama,
    NoFiccion

}