using Models;
using ContextAplication;
// using System.Data.Entity; 
namespace backEnd.Services; 

public class MovieServices 
{
    private readonly AplicationContext _context; 
    public MovieServices(AplicationContext context)
    {
        _context = context; 
    }

    public IEnumerable<Movie> Get(){

        return _context.Movies; 
    }

    public Movie? GetById(string id) {

        Guid idMovie = Guid.Parse(id); 
        var movie = _context.Movies.Find(idMovie); 

        return movie; 
    }

    public Movie Create(Movie movie) {
        
        
        _context.Movies.Add(movie);
        _context.SaveChanges();

        // var movieCreated = _context.Movies.Find(movie.MovieId); 

        _context.MovieGenders.Add(new MovieGender() {MovieId = movie.MovieId, GenderId = new Guid("77fec454-44ed-4d8e-99a9-a7f4b3682c59") }); 
        _context.SaveChanges(); 

        return movie; 
    }

    public void Update(string id, Movie movie) {
        Guid idMovie = Guid.Parse(id); 

        var movieUpdate = _context.Movies.Find(idMovie); 

        if(movieUpdate is not null) {
            movieUpdate.Title = movie.Title;
            movieUpdate.Image = movie.Image;
            movieUpdate.Duration = movie.Duration;
            movieUpdate.Date = movie.Date;
            movieUpdate.Director = movie.Director;
            movieUpdate.Actors = movie.Actors;
            movieUpdate.Qualification = movie.Qualification;

            _context.SaveChanges();
        }
    }

    public void Delete(string id){

        Guid idMovie = Guid.Parse(id); 

        var movieDelete = _context.Users.Find(idMovie); 

        if(movieDelete is not null) 
        {
            _context.Users.Remove(movieDelete); 
            _context.SaveChanges(); 
        }
    }

}