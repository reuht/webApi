
using System;
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
}


// GET 
// GET BY ID
// UserController --> /user <----Ruta 
