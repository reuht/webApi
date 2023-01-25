using Models;
using backEnd.DTOs;
using ContextAplication;
using System.Linq;

namespace backEnd.Services;



public class LoginServices {
    private readonly AplicationContext _context;
    public LoginServices(AplicationContext context){
        _context = context;
    }


    public User Login(LoginDTOin login){

        var query = from r in _context.Users where r.Name ==  login.Name && r.Pass == login.Pass select r;
        var user = query.FirstOrDefault<User>();

        return user;
    }
}