
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

    public async Task<bool> CreateBooking(ProcedureDTO booking)
    {

        Guid idMovie = Guid.Parse(booking.idMovie);
        Guid idUser = Guid.Parse(booking.idUser);

        var stock = await _context.Stocks.FindAsync(idMovie);
        var movie = await _context.Movies.FindAsync(idMovie);

        var record = await _context.UserMovies.FindAsync(idUser, idMovie);

        if (record is not null && stock.Left > 0)
        {

            int date1 = record.Delivery.Day;
            int date2 = record.Booking.Day;

            if (stock.Left == 1)
            {
                movie.SoldOut = true;
                await _context.AddRangeAsync();
            }

            if (date1 - date2 > 0)
            {

                record.Booking = DateTime.UtcNow;
                stock.Left--;
                stock.Reserved++;
                await _context.SaveChangesAsync();

                return true;
            }


        }

        if (record is null && stock.Left > 0)
        {
               if (stock.Left == 1)
            {
                movie.SoldOut = true;
                await _context.AddRangeAsync();
            }

            UserMovie registration = new UserMovie();

            registration.MovieId = idMovie;
            registration.UserId = idUser;
            registration.Booking = DateTime.UtcNow;

            //cambios en el stock 
            stock.Left--;
            stock.Reserved++;

            await _context.UserMovies.AddAsync(registration);
            await _context.SaveChangesAsync();

            return true;

        }

        return false;

    }



    public async Task<bool> CreateRent(ProcedureDTO rent)
    {
        Guid idUser = Guid.Parse(rent.idUser);
        Guid idMovie = Guid.Parse(rent.idMovie);

        var record = await _context.UserMovies.FindAsync(idUser, idMovie);
        var stock = await _context.Stocks.FindAsync(idMovie);

        if (record is not null && stock is not null)
        {
            record.DataRent = DateTime.UtcNow;
            //rent
            stock.Rented++;
            stock.Reserved--;

            await _context.SaveChangesAsync();

            return true;
        }

        return false;
    }

    public async Task<bool> CreateDelivey(ProcedureDTO delivery)
    {

        Guid idUser = Guid.Parse(delivery.idUser);
        Guid idMovie = Guid.Parse(delivery.idMovie);

        var record = await _context.UserMovies.FindAsync(idUser, idMovie);
        var stock = await _context.Stocks.FindAsync(idMovie);
        
        int days = record.Booking.Day; 

        if (days > 0 && stock is not null)
        {
            //validar que se haya hecho reserva 

            record.Delivery = DateTime.UtcNow; //fecha de entrega 
            stock.Rented--;
            stock.Left++;

            // _context.UserMovies.Remove(record); //liminar registro 

            _context.SaveChanges();
            return true;

        }
        return false;
    }
}