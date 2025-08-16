using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactDemo.Server.Database;
using ReactDemo.Server.Migrations;
using ReactDemo.Server.Models;
using System.Collections.Generic;

namespace ReactDemo.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private IPasswordHasher<AppUser> _passwordHasher;

        public UsersController(AppDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IPasswordHasher<AppUser> passwordHasher)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
        }

        // POST: users/register
        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] AppUser user)
        {
            var hasher = new PasswordHasher<AppUser>();
            user.PasswordHash = hasher.HashPassword(null, user.PasswordHash);
            user.UserName = user.Email;
            user.EmailConfirmed = true;
            try
            {
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine($"An unexpected error occurred: {e.Message}");
                return BadRequest();
            }
            return Ok();
        }

    }
}
