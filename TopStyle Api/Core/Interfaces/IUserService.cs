using TopStyle_Api.Domain.DTO;
using TopStyle_Api.Domain.Entities;
using TopStyle_Api.Domain.Identity;

namespace TopStyle_Api.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> GetUsers();
        Task<ApplicationUser> GetUserById(string id); 
        Task AddUser(ApplicationUser user, string password);  
        Task<ApplicationUser> UpdateUser(ApplicationUser user);
        Task<bool> DeleteUser(string id); 
        Task<ApplicationUser> Register(UserRegisterDTO userRegisterDTO);
        Task<string> Login(UserLoginDTO userLoginDTO);
        Task <bool> IsUserLoggedIn();
    }
}
