
using Models;
using System.Data;
using backEnd.DTOs;
using ContextAplication;
using System.Linq;

// using Microsoft.IdentityModel.Tokens;

namespace backEnd.Services;

public class RentServices
{
    private readonly AplicationContext _context;
    public RentServices(AplicationContext context)
    {
        _context = context;
    }

    public async Task<bool>CreateBooking(ProcedureDTO rent){

        Guid idMovie = Guid.Parse(rent.idMovie);
        Guid idUser = Guid.Parse(rent.idUser);

        UserMovie register = new UserMovie(); // 
        var stock = await _context.Stocks.FindAsync(idMovie);

        //busqueda usando LINQ
        var query = from r in _context.UserMovies where r.UserId == idUser && r.MovieId == idMovie select r;
        var registers = query.FirstOrDefault<UserMovie>();
        
        

        if(stock.Left > 0){

            if(registers is null) {

                if(stock.Left < rent.Movies_total){
                    return false;
                }

                if(stock.Left == rent.Movies_total){
                    var movie = await _context.Movies.FindAsync(idMovie);
                    movie.SoldOut = true;
                    await _context.SaveChangesAsync();
                }

                register.Booking = DateTime.UtcNow;
                register.MovieId = idMovie;
                register.UserId = idUser;
                register.Movies_total = rent.Movies_total;

                stock.Left -= rent.Movies_total; 
                stock.Reserved += rent.Movies_total;

                await _context.UserMovies.AddAsync(register);
                await _context.SaveChangesAsync();

                return true; 

            }

            if(registers.DataRent is null && registers.Delivery is not null)
            {

                 if(stock.Left < rent.Movies_total){
                    return false;
                }

                if(stock.Left == rent.Movies_total){
                    var movie = await _context.Movies.FindAsync(idMovie);
                    movie.SoldOut = true;
                    await _context.SaveChangesAsync();
                }

                registers.Booking = DateTime.UtcNow;
                registers.DataRent = null;
                registers.Delivery = null;
                registers.Movies_total = rent.Movies_total;

                stock.Left -= rent.Movies_total; 
                stock.Reserved += rent.Movies_total;

               
                await _context.SaveChangesAsync();

                return true; 


            }

            return false; 

        }


        return false; 
    }


    public async Task<bool>CreateRent(ProcedureDTO rent){

        Guid idMovie = Guid.Parse(rent.idMovie);
        Guid idUser = Guid.Parse(rent.idUser);

        var stock = await _context.Stocks.FindAsync(idMovie);

        //busqueda usando LINQ
        var query = from r in _context.UserMovies where r.UserId == idUser && r.MovieId == idMovie select r;
        var registers = query.FirstOrDefault<UserMovie>();

        if(registers is not null && registers.Booking is not null && registers.DataRent is null){

            var movie = await _context.Movies.FindAsync(idMovie);
            decimal price = movie.Rental_price; 
            registers.DataRent = DateTime.UtcNow;
            registers.Rental_value = price * registers.Movies_total;

            stock.Reserved -= registers.Movies_total; 
            stock.Rented+= registers.Movies_total; 

            await _context.SaveChangesAsync();

            return true;
        }
        return false; 
    }


     public async Task<bool>CreateDelivery(ProcedureDTO rent){

        Guid idMovie = Guid.Parse(rent.idMovie);
        Guid idUser = Guid.Parse(rent.idUser);

        var stock = await _context.Stocks.FindAsync(idMovie);
        var movie = await _context.Movies.FindAsync(idMovie);
   
        //busqueda usando LINQ
        var query = from r in _context.UserMovies where r.UserId == idUser && r.MovieId == idMovie select r;
        var registers = query.FirstOrDefault<UserMovie>();

        if(registers is not null && registers.DataRent is not null && registers.Delivery is null){

            if(stock.Left == 0){

                movie.SoldOut = false;
                await _context.SaveChangesAsync();

            }

            decimal price = movie.Rental_price; 
            registers.Delivery = DateTime.UtcNow;
            registers.Booking = null;
            registers.DataRent = null; 
            registers.Rental_value = price * registers.Movies_total;

            stock.Rented -= registers.Movies_total; 
            stock.Left+= registers.Movies_total; 

            await _context.SaveChangesAsync();

            return true;
        }
        return false; 
    }
    

}