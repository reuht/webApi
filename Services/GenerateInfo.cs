using Models;
using ContextAplication;
using System.Linq;

namespace backEnd.Services;


public class GenerateInfo {
    private readonly AplicationContext _context; 
    public GenerateInfo(AplicationContext context){
        _context = context; 
    }
}