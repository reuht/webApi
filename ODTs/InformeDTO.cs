
namespace backEnd.DTOs; 

public class InformeDTO{

    public Guid UserId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Identification { get; set; } = null!;
    public string Adress { get; set; } = null!;
    public string MovieTitle {get; set;} = null!;
    public string MovieImage {get; set;} =null!;
    public string DateMovie { get; set; } =  null!;
    public string MovieDuration {get; set;} =null!;
    public string DateBooking { get; set; } =  null!;
    public string DateRent { get; set; } =  null!;
    public string DateDelivery { get; set; } =  null!;
    public int TotalMovies { get; set; }
    public decimal Rental_value {get; set;}
    public decimal Fine_value {get; set;}



}