using Auth.Data;
using Auth.Data.Dtos;
using Auth.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticationController(
            UserManager<ApplicationUserEntity> userManager, RoleManager<IdentityRole> roleManager,
            AppDbContext context, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please provide all of the required fields.");
            }

            var userExists = await _userManager.FindByEmailAsync(registerDto.EmailAddress);

            if (userExists != null)
            {
                return BadRequest($"User {registerDto.EmailAddress} already exists.");
            }

            var newUser = new ApplicationUserEntity()
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.EmailAddress,
                UserName = registerDto.UserName,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(newUser, registerDto.Password);

            if (result.Succeeded)
            {
                return Ok("User created.");
            }

            return BadRequest("User could not be created.");
        }
    }
}