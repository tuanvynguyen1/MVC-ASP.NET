using Azure.Identity;
using lan2.Data;
using lan2.Data.ViewModels;
using lan2.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace lan2.Services
{
    public class AuthServices:IAuthServices
    {
        private readonly UserContext _context;
        
        public AuthServices(UserContext context)
        {
            _context = context;
        }

        /*  <summary>Service de kiem tra user co ton tai trong DB</summary>
         *  
         */
        public AuthenticateResponseViewModel? Login(AuthenticateRequestViewModel model)
        {
            User? u = _context.User.FirstOrDefault(m => m.UserName == model.Username && m.Password == Common.CommonEncryption.convertToMD5(model.Password));
            if(u == null)
            {
                return null;
            }
            return new AuthenticateResponseViewModel(u.UserName, u.Email, u.FirstName, u.LastName, generateJWTToken(u,DateTime.UtcNow.AddMonths(6)) ,generateJWTToken(u, DateTime.UtcNow.AddMinutes(10)));
        }

     

        public User? Register(RegisterRequestViewModel model)
        {
            User? u = _context.User.FirstOrDefault(m => m.UserName == model.Username || m.Email == model.Email);
            if(u != null)
            {
                return null;
            }
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = Common.CommonEncryption.convertToMD5(model.Password),
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserName = model.Username
            };
            _context.User.Add(user);
            _context.SaveChanges();
            return user;
        }
        
        private String generateJWTToken(User user, DateTime expire)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("35a8fd2cc0e1d4444fd53e75362bd6b303ff4d296f928b4ffc15ad0a1ed901c2e9e3309ad2e3ba4f27977ac8eb0603923d69dbf67fa0a5b89825291bc680ff80bdeb5d98d11b06674ecd65331670f0c97f63eb2089a58745586e69885f0c5eab6defa51a8f76081e4751033b9626775ae5133b36d97768b85258c2eae05bdf6076a758d424fa8f9f3ec58f588c58f6f340b84c195fa6781797d53a9e70611d2d5f90f979482c9b3bcc51d8333817a6df559e83a48fe3159cd11277ac5699c93c4a4eb68757a052ff45db90e533354a26cd34b884478c6088e27cb0194ac398f365f9558f5db778e50d9608f5edc5d46e30d8d45958ed1fc0ccc9aa5ebd5f0a97");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("UserId", user.Id.ToString()) }),
                Expires = expire,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
       
    }
}
