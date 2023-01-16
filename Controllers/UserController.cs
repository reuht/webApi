using Models;
using ContextAplication; 
using Microsoft.AspNetCore.Mvc; 

namespace backEnd.Controller; 


[ApiController] // atributos
[Route("[controller]")]
public class UserController: ControllerBase 
{
    private readonly AplicationContext _context; //inyeccion dependencias --> permite entrar en el context
    public UserController(AplicationContext context)
    {
        _context = context; //inyeccion dependencias
    }
    [HttpGet] //atributo ---> tipo de peticion --> ruta: /
    public IEnumerable<User>Get(){
        
        return _context.Users.ToList(); 

    } //=> _context.Users.ToList();

    [HttpGet("{id}")] //atributo ---> tipo de peticion /:id
    public ActionResult<User>GetById(int id){

        var user = _context.Users.Find(id);

        if(user is null) return NotFound();
        return user; 

    }

    [HttpPost]
    public IActionResult Create(User user){
         _context.Users.Add(user);
         _context.SaveChanges(); 
        return CreatedAtAction(nameof(GetById), new {id = user.UserId}, user);  
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, User user){

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

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id){

        Guid idUser = Guid.Parse(id); 

        var userDelete = _context.Users.Find(idUser); 

        if(userDelete is not null) 
        {
            _context.Users.Remove(userDelete); 
            _context.SaveChanges(); 
        }
        return Ok(); 
    }
}


// GET 
// GET BY ID
// POST 
// PUT 
// DELETE
// UserController --> /user <----Ruta 
