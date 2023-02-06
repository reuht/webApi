// using System.Net.Http.Headers;
// using System.Net;
// using Models;
// using backEnd.DTOs;
using System.Web;
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

        
        var content = await _services.GetExcelInfo();

        return File(content.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "informe.xlsx");
        
    }
}