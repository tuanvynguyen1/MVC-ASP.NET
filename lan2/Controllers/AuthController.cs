using lan2.Data;
using lan2.Data.ViewModels;
using lan2.Models;
using lan2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Xml.Linq;

namespace lan2.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserContext _context;

        public AuthController(UserContext context)
        {
            _context = context;
 
        }
        
         /// <summary>
         /// Authenticate User
         /// </summary>
         /// 
         /// 
         
        [ProducesResponseType(typeof(AuthenticateResponseViewModel), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 400)]
        [ProducesResponseType(typeof(ErrorViewModel), 403)]
        [ProducesResponseType(typeof(ErrorViewModel), 401)]
        [ProducesResponseType(typeof(ErrorViewModel), 500)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(typeof(ErrorViewModel), 409)]

        [Route("/login")]
        [Produces("application/json")]
        [HttpPost]
        
        public async Task<IActionResult> doLogin(AuthenticateRequestViewModel model)
        {

            AuthServices _authService = new AuthServices(_context);
            AuthenticateResponseViewModel? auth =  _authService.Login(model);
            if (auth != null)
            {
                return Common.CommonResponse.objectResult(200, "Login Successful", auth);
            }



            return Common.CommonResponse.objectResult(403, "Login FAIL!");
        }
        [Route("/register")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> doRegister(RegisterRequestViewModel model)
        {

            AuthServices _authService = new AuthServices(_context);
            User? u = _authService.Register(model);
            if (u != null)
            {
                return Common.CommonResponse.objectResult(200, "Register success");
            }
            return Common.CommonResponse.objectResult(403, "!");
        }

        [Route("/renew")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> refreshToken(RefreshTokenViewModel model)
        {
            return null;
        }

    }
}
