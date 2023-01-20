
using System.Data;
using Models;
using backEnd.DTOs;
using ContextAplication;
// using Microsoft.IdentityModel.Tokens;

namespace backEnd.Services;

public class RentServices
{
    private readonly AplicationContext _context;
    public RentServices(AplicationContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateBooking(ProcedureDTO booking)
    {
        try
        {

            Guid idMovie = Guid.Parse(booking.idMovie);
            Guid idUser = Guid.Parse(booking.idUser);

            var stock = await _context.Stocks.FindAsync(idMovie);
            var movie = await _context.Movies.FindAsync(idMovie);

            var record = await _context.UserMovies.FindAsync(idUser, idMovie);

            if (stock.Left > 0)
            {

                if (stock.Left == 1)
                {
                    movie.SoldOut = true;
                    await _context.AddRangeAsync();
                }

                if (record is null)
                {

                    var register = new UserMovie();

                    register.UserId = idUser;
                    register.MovieId = idMovie;
                    register.Booking = DateTime.UtcNow;

                    stock.Left--;
                    stock.Reserved++;

                    await _context.AddAsync(register);
                    await _context.SaveChangesAsync();

                    return true;
                }

                if (record is not null &&  record.Delivery.Hour - record.DataRent.Hour > 0 )
                {

                    record.Booking = DateTime.UtcNow;

                    stock.Left--;
                    stock.Reserved++;
                    await _context.SaveChangesAsync();

                    return true;
                }

                return false;
            }


            return false;


        }
        catch (Exception ex)
        {

            return false;

        }


    }



    public async Task<bool> CreateRent(ProcedureDTO rent)
    {
        try
        {

            Guid idUser = Guid.Parse(rent.idUser);
            Guid idMovie = Guid.Parse(rent.idMovie);

            var record = await _context.UserMovies.FindAsync(idUser, idMovie);
            var stock = await _context.Stocks.FindAsync(idMovie);

            if (record.DataRent.Day == 1 && record.Booking.Day > 1)
            {

                record.DataRent = DateTime.UtcNow;
                stock.Rented++;
                stock.Reserved--;
                await _context.SaveChangesAsync();

                return true;
            }

            if (record.DataRent.Day != 1 && record.Delivery.Hour - record.DataRent.Hour > 0)
            {

                record.DataRent = DateTime.UtcNow;
                stock.Rented++;
                stock.Reserved--;
                await _context.SaveChangesAsync();

                return true;

            }

            return false;

        }
        catch (Exception ex)
        {
            return false;
        }
    }


    public async Task<bool> CreateDelivey(ProcedureDTO delivery)
    {
        try
        {
            Guid idUser = Guid.Parse(delivery.idUser);
            Guid idMovie = Guid.Parse(delivery.idMovie);

            var record = await _context.UserMovies.FindAsync(idUser, idMovie);
            var stock = await _context.Stocks.FindAsync(idMovie);


            if (record.DataRent.Day != 1 && record.Delivery.Day == 1)
            {
                record.Delivery = DateTime.UtcNow; //fecha de entrega 
                stock.Rented--;
                stock.Left++;


                _context.SaveChanges();
                return true;

            }

            if (record.Delivery.Day != 1 && record.Delivery.Day - DateTime.UtcNow.Day < 0)
            {

                record.Delivery = DateTime.UtcNow; //fecha de entrega nueva
                stock.Rented--;
                stock.Left++;

                _context.SaveChanges();
                return true;

            }

            return false;


        }
        catch (Exception ex)
        {
            return false;
        }


    }

}