using backEnd.DTOs;
using backEnd.Services;  
using Microsoft.AspNetCore.Mvc; 

namespace backEnd.Controller; 

[ApiController] // atributos
[Route("/Rents")]
public class RentsController: ControllerBase {

    private readonly RentServices _services; 
    public RentsController(RentServices services){
        
        _services = services; 
    }

    [HttpPost("Booking")]
    public async Task<ActionResult>CreateBooking(BookingDTO booking)
    {

        bool iscreteBooking = await _services.CreateBooking(booking);
        
        return iscreteBooking ? Ok(new {msg = "Se a reservado la pelicula"}) : BadRequest(new {msg = "Pelicula agotada" }); 
    }

    [HttpPost("Rented")]
    public async Task<ActionResult>CreateRented()
    {
        
        return Ok(); 
    }



}