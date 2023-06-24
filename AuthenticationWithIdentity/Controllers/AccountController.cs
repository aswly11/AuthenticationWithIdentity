using AuthenticationWithIdentity.Models;
using AuthenticationWithIdentity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AuthenticationWithIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly TokenService _tokenService;


        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            TokenService tokenService)
        {

            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;

        }

        [HttpPost("AddUser")]
        [Authorize(Roles ="Admin")]

        public async Task<IActionResult> AddUser([FromBody] RegisterModel registerModel)
        {

            ApplicationUser applicationUser = new ApplicationUser();
            applicationUser.Email = registerModel.Email;
            applicationUser.UserName = registerModel.UserName;

            var result = await _userManager.CreateAsync(applicationUser, registerModel.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(applicationUser, "Member");
                return Ok(applicationUser);
            }
            return BadRequest("Register Failed");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] RegisterModel loginModel)
        {
            string token = await _tokenService.GenerateTokenAsync(loginModel.Email, loginModel.Password);
            if (token == null)
            {
                // Handle authentication failure
                return Unauthorized();
            }

            // Handle successful authentication
            return Ok(new { Token = token });

        }

    }
}
