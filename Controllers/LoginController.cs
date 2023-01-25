// using System;
// using System.Net.Mime;
using Models;
using backEnd.DTOs;
using backEnd.Services;  
using Microsoft.AspNetCore.Mvc; 

namespace backEnd.Controller; 

[ApiController] // atributos
[Route("[controller]")]
public class LoginController: ControllerBase{

    private readonly LoginServices _services;
    public LoginController(LoginServices services){

        _services = services; 

    }

    [HttpPost]
    public IActionResult getUser(LoginDTOin login){

        var user = _services.Login(login);

       if(user is not null){
        return Ok();
       }

       return BadRequest();
    }


}