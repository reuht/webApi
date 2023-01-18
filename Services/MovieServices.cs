using Models;
using backEnd.DTOs; 
using ContextAplication;
using Microsoft.EntityFrameworkCore;

namespace backEnd.Services; 

public class MovieServices 
{
    private readonly AplicationContext _context; 
    public MovieServices(AplicationContext context)
    {
        _context = context; 
    }

    public async Task<IEnumerable<Movie>> Get(){

        return await _context.Movies.ToListAsync(); 
    }

    public async Task<Movie>? GetById(string id) {

        Guid idMovie = Guid.Parse(id); 
        var movie = await _context.Movies.FindAsync(idMovie); 

        return movie; 
    }

    public async Task<Movie> Create(MovieDTOin movie) {

        var newMovie = new Movie(); 
        Gender value = (Gender)((int)(movie.Gender)); //Conversion 

        newMovie.Title = movie.Title;
        newMovie.Image = movie.Image; 
        newMovie.Duration = movie.Duration;
        newMovie.Date = movie.Date; 
        newMovie.Director = movie.Director;
        newMovie.Actors = movie.Actors;
        newMovie.Qualification = movie.Qualification;
        newMovie.Gender = value; 

        await _context.Movies.AddAsync(newMovie);
        await _context.SaveChangesAsync();

        return newMovie; 
    }

    public async Task Update(string id, MovieDTOin movie) {
       
        Guid idMovie = Guid.Parse(id); 

        var movieUpdate = await _context.Movies.FindAsync(idMovie); 


        if(movieUpdate is not null) {

            Gender value = (Gender)((int)(movieUpdate.Gender));
        
            movieUpdate.Title = movie.Title;
            movieUpdate.Image = movie.Image;
            movieUpdate.Duration = movie.Duration;
            movieUpdate.Date = movie.Date;
            movieUpdate.Director = movie.Director;
            movieUpdate.Actors = movie.Actors;
            movieUpdate.Gender = value; 
            movieUpdate.Qualification = movie.Qualification;

             await _context.SaveChangesAsync();
        }
    }

    public async Task Delete(string id){

        Guid idMovie = Guid.Parse(id); 

        var movieDelete = await _context.Users.FindAsync(idMovie); 

        if(movieDelete is not null) 
        {
             _context.Users.Remove(movieDelete); 
            await _context.SaveChangesAsync(); 
        }
    }

}