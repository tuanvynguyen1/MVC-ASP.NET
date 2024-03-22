using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lan2.Data;
using lan2.Models;
using lan2.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace lan2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: api/
        [Route("me")]
        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> getAuth()
        {
            var userid = User.Claims.Where(x => x.Type == "UserId").FirstOrDefault()?.Value;
            if (userid == null || userid == string.Empty)
            {
                return Unauthorized();
            }
            int id = int.Parse(userid);

            return Common.CommonResponse.objectResult(200, "", _context.User.Include(x => x.userSkills).FirstOrDefault(x => x.Id == id));
        }
        [Route("update")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> updateInfomation(UpdateRequestViewModel model)
        {
            var userid = User.Claims.Where(x => x.Type == "UserId").FirstOrDefault()?.Value;
            if (userid == null || userid == string.Empty)
            {
                return Unauthorized();
            }
            int id = int.Parse(userid);
            User? user = _context.User.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return Unauthorized();
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PhoneNumber = model.Phonenumber;
            _context.SaveChanges();
            return Common.CommonResponse.objectResult(200, "Update Successful!");

        }
        [Route("ChangePassword")]
        [HttpPost]

        public async Task<IActionResult> updatePassword()
        {
            return null;
        }
    }
}
