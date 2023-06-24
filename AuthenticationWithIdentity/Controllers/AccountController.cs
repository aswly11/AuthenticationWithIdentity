using AuthenticationWithIdentity.Data;
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
        private readonly ApplicationContext _context;


        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            TokenService tokenService, ApplicationContext context)
        {

            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("AddUser")]
        [Authorize(Roles = "Admin")]

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

            return BadRequest(result.Errors);
        }
        [HttpPost("AddPage")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> AddAction(string pageName)
        {
            if (ModelState.IsValid)
            {
                var page = new Page { Name = pageName };
                _context.Pages.Add(page);
                _context.SaveChanges();
                return Ok(page);
            }
            return BadRequest(ModelState.Values.SelectMany(v => v.Errors));
        }


        [HttpPost("AddAction")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> AddAction([FromBody] PageAction pageAction)
        {
            if (ModelState.IsValid)
            {
                _context.PageActions.Add(pageAction);
                _context.SaveChanges();

                return Ok(pageAction);
            }
            return BadRequest(ModelState.Values.SelectMany(v => v.Errors));
        }

        [HttpPost("AddRoleAction")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> AddRoleAction([FromBody] ApplicationRole applicationRole)
        {
            if (ModelState.IsValid)
            {
                _context.ApplicationRoles.Add(applicationRole);
                _context.SaveChanges();

                return Ok(applicationRole);
            }
            return BadRequest(ModelState.Values.SelectMany(v => v.Errors));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] RegisterModel loginModel)
        {
            var authModel = await _tokenService.GenerateTokenAsync(loginModel.Email, loginModel.Password);
            if (authModel == null)
            {
                // Handle authentication failure
                return Unauthorized();
            }

            // Handle successful authentication
            return Ok(authModel);

        }



    }
}
