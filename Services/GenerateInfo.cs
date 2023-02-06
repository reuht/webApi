using System.Data;
using Models;
using System.Linq;
using ContextAplication;
using backEnd.DTOs;
using SpreadsheetLight;
using Microsoft.EntityFrameworkCore;

namespace backEnd.Services;


public class GenerateInfo {

    private readonly AplicationContext _context; 

    public GenerateInfo(AplicationContext context){
        _context = context; 
    }

    public async Task<MemoryStream> GetExcelInfo(){
        try {

            var informeUsers = await _context.UserMovies.Select(p => new InformeDTO {

                UserId = p.UserId,
                Name = p.User.Name,
                Email = p.User.Email,
                Identification= p.User.Identification,
                Adress = p.User.Adress,
                MovieTitle = p.Movie.Title,
                MovieImage = p.Movie.Image,
                MovieDuration = p.Movie.Duration,
                DateMovie = p.Movie.Date,
                DateBooking = p.Booking.ToString(),
                DateRent = p.DataRent.ToString(),
                DateDelivery = p.Delivery.ToString(),
                TotalMovies = p.Movies_total,
                Rental_value = p.Rental_value,
                Fine_value = p.Fine_value

            }).ToListAsync(); 

            SLDocument firtSheetUser = new SLDocument(); 
            DataTable FirstTableUser = new DataTable();

    
            //Titles columns 
            FirstTableUser.Columns.Add("UserId", typeof(string));
            FirstTableUser.Columns.Add("Name", typeof(string));
            FirstTableUser.Columns.Add("Email", typeof(string));
            FirstTableUser.Columns.Add("Identification", typeof(string));
            FirstTableUser.Columns.Add("Adress", typeof(string));
            FirstTableUser.Columns.Add("Titulo Pelicula", typeof(string));
            FirstTableUser.Columns.Add("Poster", typeof(string));
            FirstTableUser.Columns.Add("Duracion", typeof(string));
            FirstTableUser.Columns.Add("Fecha", typeof(string));
            FirstTableUser.Columns.Add("Fecha de Reserva", typeof(string));
            FirstTableUser.Columns.Add("Fecha de Renta", typeof(string));
            FirstTableUser.Columns.Add("Fecha de Entrega", typeof(string));
            FirstTableUser.Columns.Add("# Peliculas", typeof(int));
            FirstTableUser.Columns.Add("Valor de Renta", typeof(string));
            FirstTableUser.Columns.Add("Valor Total de Renta", typeof(string));

            foreach(InformeDTO info in informeUsers){

                FirstTableUser.Rows.Add(

                                        info.UserId.ToString(), 
                                        info.Name, 
                                        info.Email, 
                                        info.Identification, 
                                        info.Adress,
                                        info.MovieTitle,
                                        info.MovieImage,
                                        info.MovieDuration,
                                        info.DateMovie,
                                        info.DateBooking,
                                        info.DateRent,
                                        info.DateDelivery,
                                        info.TotalMovies,
                                        info.Rental_value,
                                        info.Fine_value
                                        );
            }
            
          
            firtSheetUser.ImportDataTable(1, 1, FirstTableUser, true);
       

            
            var data = new MemoryStream();
            firtSheetUser.SaveAs(data); 

            
           //byte [] document = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "Informe.xlsx");

           return data;

        }catch(Exception ex){
            return null;
        }
    }
}


