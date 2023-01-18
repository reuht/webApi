
using Models;
using backEnd.DTOs;
using ContextAplication;
using Microsoft.EntityFrameworkCore;

namespace backEnd.Services; 

public class UserServices 
{
    private readonly AplicationContext _context; 
    public UserServices(AplicationContext context)
    {
        _context = context; 
    }

    
    public async Task<IEnumerable<User>>Get()
    {
        
        return await _context.Users.ToListAsync(); 

    } //=> _context.Users.ToList();

   
    public async Task<User>? GetById(string id)
    {

        Guid idUser = Guid.Parse(id); 
        var user = await _context.Users.FindAsync(idUser);
        
        return user; 
    }


    public async Task<User> Create(UserDTO user)
    {
         var newUser = new User(); 
         Rol value = (Rol)((int)(user.Roluser)); 

         newUser.Name = user.Name; 
         newUser.Email = user.Email;
         newUser.Pass = user.Pass;
         newUser.Identification = user.Identification;
         newUser.Adress = user.Adress;
         newUser.Roluser = value; 

         await _context.Users.AddAsync(newUser);
         await _context.SaveChangesAsync(); 
        return newUser;  
    }


    public async Task Update(string id, User user)
    {

        Guid idUser = Guid.Parse(id);

        var userUpdate = await _context.Users.FindAsync(idUser); 

        if(userUpdate is not null) 
        {
            userUpdate.Name = user.Name; 
            userUpdate.Email = user.Email;
            userUpdate.Identification = user.Identification;
            userUpdate.Pass = user.Pass; 
            userUpdate.Adress = user.Adress;
            
            await _context.SaveChangesAsync(); 
        }
    }

  
    public async Task Delete(string id)
    {

        Guid idUser = Guid.Parse(id); 

        var userDelete = _context.Users.Find(idUser); 

        if(userDelete is not null) 
        {
            _context.Users.Remove(userDelete); 
            await _context.SaveChangesAsync(); 
        }
    }
}