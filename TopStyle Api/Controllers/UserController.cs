using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using TopStyle_Api.Core.Interfaces;
using TopStyle_Api.Domain.DTO;
using TopStyle_Api.Domain.Identity;

namespace TopStyle_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(IMapper mapper, ITokenService tokenService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _mapper = mapper;
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO userRegisterDTO)
        {
            var userExists = await _userManager.FindByNameAsync(userRegisterDTO.Username);
            if (userExists != null)
            {
                return BadRequest("Username already taken.");
            }

            var user = _mapper.Map<ApplicationUser>(userRegisterDTO);
            var result = await _userManager.CreateAsync(user, userRegisterDTO.Password);

            if (!result.Succeeded)
            {
                // Properly format error messages for the client
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new { Errors = errors });
            }

            return Ok("User registered successfully.");
        }


        //[HttpPost("login")]
        //public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        //{
        //    var user = await _userManager.FindByNameAsync(userLoginDTO.Username);
        //    if (user == null)
        //    {
        //        return Unauthorized("Invalid username.");
        //    }

        //    var result = await _signInManager.CheckPasswordSignInAsync(user, userLoginDTO.Password, lockoutOnFailure: false);
        //    if (!result.Succeeded)
        //    {
        //        return Unauthorized("Invalid password.");
        //    }

        //    var token = _tokenService.CreateToken(user);
        //    return Ok(new { Token = token });
        //}

        //// check if user is authenticated
        //[HttpGet("authenticated")]
        //public async Task<IActionResult> IsAuthenticated()
        //{
        //    var authenticated = User.Identity.IsAuthenticated;
        //    var user = await _userManager.FindByNameAsync(User.Identity.Name);
        //    return Ok(new { Authenticated = authenticated, Username = user.UserName });
        //} 
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            var user = await _userManager.FindByNameAsync(userLoginDTO.Username);
            if (user == null)
            {
                return Unauthorized("Invalid username.");
            }

            // Enable lockout on failure to prevent brute force attacks
            var result = await _signInManager.CheckPasswordSignInAsync(user, userLoginDTO.Password, lockoutOnFailure: true);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    return Unauthorized("Account locked due to too many failed attempts. Please try again later.");
                }
                return Unauthorized("Invalid password.");
            }

            var token = _tokenService.CreateToken(user.Id);
            return Ok(new { Token = token });
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(users);
        }

    }
}
