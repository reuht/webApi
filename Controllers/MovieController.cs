using Models;
using backEnd.Services;  
using Microsoft.AspNetCore.Mvc; 

namespace backEnd.Controller; 

[ApiController] // atributos
[Route("[controller]")]
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

    [HttpGet("{id}")]
    public ActionResult<Movie> GetById(string id){
        
        var movie = _services.GetById(id);

        if(movie is null) return NotFound();

        return movie; 
    }

    [HttpPost] 
    public IActionResult Create(Movie movie){

        var newMovie = _services.Create(movie); 

        return CreatedAtAction(nameof(GetById), new {id = newMovie.MovieId}, movie);
    }
    [HttpPut("{id}")]
    public IActionResult Update(string id, Movie movie) {
        _services.Update(id, movie);
        return Ok(); 
    }
}