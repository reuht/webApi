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

    public async Task<IEnumerable<MovieDTOout>> Get()
    {
        try
        {

            return await _context.Movies.Select(a => new MovieDTOout
            {

                MovieId = a.MovieId,
                Title = a.Title,
                Image = a.Image,
                Total = a.Stock.Total,
                Left = a.Stock.Left,
                Rented = a.Stock.Rented,

            }).ToListAsync();
        }
        catch (Exception ex)
        {

            return null;
        }

    }

    public async Task<Movie>? GetById(string id)
    {
        try
        {

            Guid idMovie = Guid.Parse(id);
            var movie = await _context.Movies.FindAsync(idMovie);

            return movie;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<Movie> Create(MovieDTOin movie)
    {
        try
        {

            var newMovie = new Movie();
            var stock = new Stock();

            Gender value = (Gender)((int)(movie.Gender)); //Conversion 

            newMovie.MovieId = Guid.NewGuid();
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

            //---Cargar Stock 
            stock.MovieId = newMovie.MovieId;
            stock.Total = movie.Total;
            stock.Left = movie.Total;

            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();

            return newMovie;
        }
        catch (Exception ex)
        {
            return null;
        }

    }

    public async Task Update(string id, MovieDTOin movie)
    {
        try
        {

            Guid idMovie = Guid.Parse(id);

            var update = await _context.Movies.FindAsync(idMovie);


            if (update is not null)
            {

                Gender value = (Gender)((int)movie.Gender);
                //crear nuevamente con el anterior id 

                update.MovieId = idMovie;
                update.Title = movie.Title;
                update.Image = movie.Image;
                update.Duration = movie.Duration;
                update.Date = movie.Date;
                update.Director = movie.Director;
                update.Actors = movie.Actors;
                update.Gender = value;
                update.Qualification = movie.Qualification;

                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            return;
        }

    }

    public async Task Delete(string id)
    {
        try
        {

            Guid idMovie = Guid.Parse(id);

            var movieDelete = await _context.Movies.FindAsync(idMovie);

            if (movieDelete is not null)
            {
                _context.Movies.Remove(movieDelete);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            return;
        }

    }

}