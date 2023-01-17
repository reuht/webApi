
using Models;
using ContextAplication;

namespace backEnd.Services; 

public class UserServices 
{
    private readonly AplicationContext _context; 
    public UserServices(AplicationContext context)
    {
        _context = context; 
    }

    
    public IEnumerable<User>Get()
    {
        
        return _context.Users.ToList(); 

    } //=> _context.Users.ToList();

   
    public User? GetById(string id)
    {

        Guid idUser = Guid.Parse(id); 
        var user = _context.Users.Find(idUser);
        
        return user; 
    }


    public User Create(User user)
    {
         _context.Users.Add(user);
         _context.SaveChanges(); 
        return user;  
    }


    public void Update(string id, User user)
    {

        Guid idUser = Guid.Parse(id);

        var userUpdate = _context.Users.Find(idUser); 

        if(userUpdate is not null) 
        {
            userUpdate.Name = user.Name; 
            userUpdate.Email = user.Email;
            userUpdate.Identification = user.Identification;
            userUpdate.Pass = user.Pass; 
            userUpdate.Adress = user.Adress;
            _context.SaveChanges(); 
        }
    }

  
    public void Delete(string id)
    {

        Guid idUser = Guid.Parse(id); 

        var userDelete = _context.Users.Find(idUser); 

        if(userDelete is not null) 
        {
            _context.Users.Remove(userDelete); 
            _context.SaveChanges(); 
        }
    }
}