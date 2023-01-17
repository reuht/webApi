using Models;
using backEnd.Services;  
using Microsoft.AspNetCore.Mvc; 

namespace backEnd.Controller; 


[ApiController] // atributos
[Route("[controller]")]
public class UserController: ControllerBase 
{
    private readonly UserServices _services; //inyeccion dependencias --> permite entrar en el context
    public UserController(UserServices services)
    {
        _services = services; //inyeccion dependencias
    }
    [HttpGet] //atributo ---> tipo de peticion --> ruta: /
    public IEnumerable<User>Get(){

        return _services.Get(); 
    } //=> _services.Users.ToList();

    [HttpGet("{id}")] //atributo ---> tipo de peticion /:id
    public ActionResult<User>GetById(string id){

        var user = _services.GetById(id);

        if(user is null) return NotFound();

        return user; 

    }

    [HttpPost]
    public IActionResult Create(User user){
        var newUser = _services.Create(user); 

        return CreatedAtAction(nameof(GetById), new {id = newUser.UserId}, newUser); 
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, User user)
    {
        _services.Update(id, user); 
        return Ok(); 
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _services.Delete(id); 
        return Ok();
    }

}



