using Models;
using backEnd.DTOs;
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
    public async Task<IEnumerable<User>>Get(){

        return await _services.Get(); 
    } //=> _services.Users.ToList();

    [HttpGet("{id}")] //atributo ---> tipo de peticion /:id
    public async Task<ActionResult<User>>GetById(string id){

        var user = await _services.GetById(id);

        if(user is null) return NotFound();

        return user; 

    }

    [HttpPost]
    public async Task<IActionResult> Create(UserDTO user){

        var newUser = await _services.Create(user); 

        return CreatedAtAction(nameof(GetById), new {id = newUser.UserId}, newUser); 
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, User user)
    {
        await _services.Update(id, user); 
        return Ok(); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _services.Delete(id); 
        return Ok();
    }

}



