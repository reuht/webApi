using Models; 
using ContextAplication; 

namespace backEnd.Services; 

public class GenderServices {

    private readonly AplicationContext _context; 

    public GenderServices(AplicationContext context){
        _context = context; 
    }

    public IEnumerable<Gender>Get() 
    {
        return _context.Genders.ToList(); 
    }

    public Gender GetById(string id)
    {
        Guid idGender = Guid.Parse(id); 
        return _context.Genders.Find(idGender); 
    }

    public void Create(Gender gender){
        _context.Genders.Add(gender);
        _context.SaveChanges();
    }
}