using System.Net;
using Models;
using backEnd.DTOs;
using backEnd.Services;  
using Microsoft.AspNetCore.Mvc;
using SpreadsheetLight;

namespace backEnd.Controller; 

[ApiController] // atributos
[Route("[controller]")]
public class ReportController: ControllerBase  
{
    private readonly GenerateInfo _services; 
    public ReportController(GenerateInfo services)
    {
        _services = services; 
    }

    [HttpGet]
    public async Task<IActionResult> GetInfo(){

        SLDocument info = await _services.GetExcelInfo();
        
        return File(info,);
    }

}