// using System;
using Models;
using backEnd.DTOs;
using ContextAplication;

namespace backEnd.Services;

public class RentServices
{
    private readonly AplicationContext _context;
    public RentServices(AplicationContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateBooking(BookingDTO booking) 
    {

        Guid idMovie = Guid.Parse(booking.idMovie);
        Guid idUser = Guid.Parse(booking.idUser);  

        var stock = await _context.Stocks.FindAsync(idMovie);
        var movie = await _context.Movies.FindAsync(idMovie);
        
        if(stock.Left > 0)
        {
             if( stock.Left == 1) {

                movie.SoldOut = true; 
                await _context.SaveChangesAsync(); 
            }

            UserMovie registration = new UserMovie(); 

            registration.MovieId = idMovie; 
            registration.UserId = idUser; 
            registration.Booking = DateTime.UtcNow;

            //cambios en el stock 
            stock.Left = stock.Left - 1; 
            stock.Reserved++; 

            await _context.UserMovies.AddAsync(registration);
            await _context.SaveChangesAsync(); 

           

            return true; 
            
        }

        return false; 
    }



    
}