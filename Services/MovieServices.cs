using Models;
using ContextAplication;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Services; 

public class MovieServices 
{
    private readonly AplicationContext _context; 
    public MovieServices(AplicationContext context)
    {
        _context = context; 
    }

    [HttpGet]
    public IEnumerable<Movie> Get(){

        return _context.Movies.ToList(); 
    }

    [HttpGet("{id}")]
    public Movie? GetById(string id) {
        Guid idMovie = Guid.Parse(id); 
        return _context.Movies.Find(idMovie); 
    }

    [HttpPost]
    public Movie Create(Movie movie) {
        _context.Movies.Add(movie); 
        _context.SaveChanges();
        return movie; 
    }

    
}