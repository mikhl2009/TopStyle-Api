using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using TopStyle_Api.Core.Interfaces;
using TopStyle_Api.Data.Interfaces;
using TopStyle_Api.Domain.DTO;
using TopStyle_Api.Domain.Entities;
using TopStyle_Api.Domain.Identity;

namespace TopStyle_Api.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepo userRepo, ITokenService tokenService, IMapper mapper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddUser(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                throw new Exception($"Failed to create user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }

        public Task<bool> DeleteUser(string id)
        {
            _mapper.Map<ApplicationUser>(id);
            return _userRepo.DeleteUser(id);
        }



        public Task<ApplicationUser> GetUserById(string id)
        {
            _mapper.Map<ApplicationUser>(id);
            return _userRepo.GetUserById(id);
        }

        public Task<IEnumerable<ApplicationUser>> GetUsers()
        {
            return _userRepo.GetUsers();
        }

        public async Task<bool> IsUserLoggedIn()
        {
            // use identity to check if user is logged in
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;


        }

        public async Task<string> Login(UserLoginDTO userLoginDTO)
        {
            var user = await _userManager.FindByNameAsync(userLoginDTO.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, userLoginDTO.Password))
            {
                // Directly return the string token
                return _tokenService.CreateToken(user.Id);
            }
            throw new Exception("Invalid username or password");
        }

        public Task<ApplicationUser> Register(UserRegisterDTO userRegisterDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> UpdateUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
    //{
    //    private readonly IUserRepo _userRepo;
    //    private readonly ITokenService _tokenService;
    //    private readonly IMapper _mapper;
    //    private readonly UserManager<ApplicationUser> _userManager;
    //    private readonly SignInManager<ApplicationUser> _signInManager;

    //public UserService(IUserRepo userRepo, ITokenService tokenService, IMapper mapper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    //{
    //    _userRepo = userRepo;
    //    _tokenService = tokenService;
    //    _mapper = mapper;
    //    _userManager = userManager;
    //    _signInManager = signInManager;
    //}

    //public async Task AddUser(ApplicationUser user, string password)
    //{
    //    var result = await _userManager.CreateAsync(user, password);
    //    if (!result.Succeeded)
    //    {
    //        throw new Exception($"Failed to create user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
    //    }
    //}

    //public Task<bool> DeleteUser(string id)
    //{
    //    _mapper.Map<ApplicationUser>(id);
    //    return _userRepo.DeleteUser(id);
    //}

    //public Task<ApplicationUser> GetUserById(string id)
    //{
    //    _mapper.Map<ApplicationUser>(id);
    //    return _userRepo.GetUserById(id);
    //}

    //public Task<IEnumerable<ApplicationUser>> GetUsers()
    //{
    //    return _userRepo.GetUsers();
    //}

    //public async Task<string> Login(UserLoginDTO userLoginDTO)
    //{
    //    var user = await _userManager.FindByNameAsync(userLoginDTO.Username);
    //    if (user != null && await _userManager.CheckPasswordAsync(user, userLoginDTO.Password))
    //    {
    //        return _tokenService.CreateToken(user);
    //    }
    //    throw new Exception("Invalid username or password");
    //}

    //public Task<ApplicationUser> Register(UserRegisterDTO userRegisterDTO)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<ApplicationUser> UpdateUser(ApplicationUser user)
    //{
    //    throw new NotImplementedException();
    //}
    //}
}
