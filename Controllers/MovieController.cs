using Models;
using backEnd.Services;  
using Microsoft.AspNetCore.Mvc; 

namespace backEnd.Controller; 

[ApiController] // atributos
[Route("/movies")]
public class MovieController: ControllerBase  
{
    private readonly MovieServices _services; 
    public MovieController(MovieServices services)
    {
        _services = services; 
    }

    [HttpGet]
    public IEnumerable<Movie> Get(){
        return _services.Get(); 
    }
}