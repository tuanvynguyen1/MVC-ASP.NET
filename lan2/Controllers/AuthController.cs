using lan2.Data;
using lan2.Data.ViewModels;
using lan2.Models;
using lan2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using System.Xml.Linq;

namespace lan2.Controllers
{
    [ApiController]
    public class AuthController : Controller
    {
        private readonly UserContext _context;
        
        
        public AuthController(UserContext context)
        {
            _context = context;
        }

        //[Route("login")]
        //[HttpGet]
        //public async Task<IActionResult> LoginPage()
        //{
        //    return View();
        //}
        [Route("/login")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> doLogin([FromForm] AuthenticateRequestViewModel model)
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
        public async Task<IActionResult> doRegister([FromForm] RegisterRequestViewModel model)
        {

            AuthServices _authService = new AuthServices(_context);
            User? u = _authService.Register(model);
            if (u != null)
            {
                return Common.CommonResponse.objectResult(200, "Register success");
            }
            return Common.CommonResponse.objectResult(403, "Login FAIL!");
        }



    }
}
