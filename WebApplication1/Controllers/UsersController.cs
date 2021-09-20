using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.OutModels;
using WebApplication1.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{

    [Route("api/users/")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly ForumContext _context;

        public UsersController(ForumContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet] //get all users
        public  ActionResult<List<UserOut>> getAllUsers()
        {
            return _context.Users.Select(u => new UserOut(u.Id, u.FirstName, u.LastName)).ToList();
        }

        [HttpPost("register")] //register user
        public ActionResult registerUser(User user)
        {
            var result = _context.Users.FirstOrDefault(u => u.Login == user.Login);
            if (result == null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok(new MessageLogger(Messages.USER_SUCCESSFULLY_CREATED));
            }
            return BadRequest(new MessageLogger(Messages.USER_ALREADY_EXIST));
        }

        [HttpPost("login")] //login user
        public async Task<ActionResult> loginUserAsync(LoginUser user)
        {
            var result = _context.Users.FirstOrDefault(u => u.Login == user.Login && u.Password == user.Password);
            if (result != null)
            {
                await AuthUser(result.Id.ToString());

                return Ok(new MessageLogger(Messages.USER_SUCCESSFULLY_LOGIN,result.Id.ToString()));
            }
            return NotFound(new MessageLogger(Messages.USER_INCORRECT_LOGIN));
        }

        private async Task AuthUser(string Id) //auth user method
        {
            var claims = new List<Claim> //key <=> value data  save for cookies
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType,Id)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "Cookies");
            await Request.HttpContext.SignInAsync("Cookies",new ClaimsPrincipal(id));
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync();
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
