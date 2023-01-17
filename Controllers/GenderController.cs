using Models; 
using backEnd.Services;
using Microsoft.AspNetCore.Mvc; 

[ApiController]
[Route("[controller]")]

public class GenderController : ControllerBase {
    private readonly GenderServices _services; 
    public GenderController(GenderServices services)
    {
        _services = services; 
    }

    [HttpGet]
    public IEnumerable<Gender> Get() 
    {
        return _services.Get(); 
    }

    [HttpGet("{id}")]
    public ActionResult<Gender> GetById(string id)
    {
        var Gender = _services.GetById(id); 
        if(Gender is null) return BadRequest();

        return Gender; 
    }
    
    [HttpPost]
    public IActionResult Create(Gender gender)
    {
        _services.Create(gender); 
        return Ok(); 
    }
}