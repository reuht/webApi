using backEnd.DTOs;
using backEnd.Services;  
using Microsoft.AspNetCore.Mvc; 

namespace backEnd.Controller; 

[ApiController] // atributos
[Route("[controller]")]
public class RentsController: ControllerBase {

    private readonly RentServices _services; 
    public RentsController(RentServices services){
        
        _services = services; 
    }

    [HttpPost]
    public async Task<ActionResult> Create(BookingDTO booking){

        await _services.CreateBooking(booking);

        return Ok(); 
    }


}