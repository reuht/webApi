
using Models;
using ContextAplication;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Services; 

public class UserServices 
{
    private readonly AplicationContext _context; 
    public UserServices(AplicationContext context)
    {
        _context = context; 
    }

    [HttpGet] //atributo ---> tipo de peticion --> ruta: /
    public IEnumerable<User>Get(){
        
        return _context.Users.ToList(); 

    } //=> _context.Users.ToList();

    [HttpGet("{id}")] //atributo ---> tipo de peticion /:id
    public User? GetById(int id){

        var user = _context.Users.Find(id);

        return user; 
    }

    [HttpPost]
    public User Create(User user){
         _context.Users.Add(user);
         _context.SaveChanges(); 
        return user;  
    }

    [HttpPut("{id}")]
    public void Update(string id, User user){

        Guid idUser = Guid.Parse(id);

        var userUpdate = _context.Users.Find(idUser); 

        if(userUpdate is not null) {
            userUpdate.Name = user.Name; 
            userUpdate.Email = user.Email;
            userUpdate.Identification = user.Identification;
            userUpdate.Pass = user.Pass; 
            userUpdate.Adress = user.Adress;
            _context.SaveChanges(); 
        }
    }

    [HttpDelete("{id}")]
    public void Delete(string id){

        Guid idUser = Guid.Parse(id); 

        var userDelete = _context.Users.Find(idUser); 

        if(userDelete is not null) 
        {
            _context.Users.Remove(userDelete); 
            _context.SaveChanges(); 
        }
    }
}