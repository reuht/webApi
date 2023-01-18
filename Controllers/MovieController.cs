using Models;
using backEnd.DTOs;
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
    public async Task<IEnumerable<Movie>> Get()
    {
        return await _services.Get(); 
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> GetById(string id)
    {
        var movie = await _services.GetById(id);

        if(movie is null) return NotFound();

        return movie; 
    }

    [HttpPost] 
    public async Task<IActionResult> Create(MovieDTOin movie)
    {

        var newMovie = await _services.Create(movie); 

        return CreatedAtAction(nameof(GetById), new {id = newMovie.MovieId}, movie);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, MovieDTOin movie) 
    {
        await _services.Update(id, movie);
        return Ok(); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _services.Delete(id); 
        return Ok(); 
    }
}