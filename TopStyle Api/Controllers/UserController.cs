using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
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

        [HttpGet("Me")]
        [Authorize]
        public async Task<IActionResult> GetMyInfo()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound("User not found.");

            var userInfo = new
            {
                user.UserName,
                user.Email,
                
            };

            return Ok(userInfo);
        }

        
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
