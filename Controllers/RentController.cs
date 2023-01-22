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
    public async Task<ActionResult>CreateBooking(ProcedureDTO booking)
    {

        bool iscreteBooking = await _services.CreateBooking(booking);
        
        return iscreteBooking ? Ok(new {msg = "Se a reservado la pelicula"}) : BadRequest(); 
    }

    [HttpPost("Rented")]
    public async Task<ActionResult>CreateRented(ProcedureDTO rent)
    {
        var result = await _services.CreateRent(rent);
        
        return Ok(new{msg = result}); 
    }

    [HttpPost("Delivery")]
    public async Task<ActionResult>CreateDelivery(ProcedureDTO delivery){

        bool result = await _services.CreateDelivery(delivery); 

        return result ? Ok(new {msg = "Entrega realizada"}) : BadRequest();
    }


}