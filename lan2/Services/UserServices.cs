
using lan2.Data;
using lan2.Data.ViewModels;
using lan2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace lan2.Services
{
    public class UserServices: IUserServices
    {
        private readonly UserContext _context;

        public UserServices(UserContext context)
        {
            _context = context;
        }




        User? IUserServices.GetUserByID(int id)
        {
            User? user =  _context.User
                .FirstOrDefault(m => m.Id == id);
            return user;
        }
    }
}
