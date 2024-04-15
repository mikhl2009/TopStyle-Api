using TopStyle_Api.Domain.DTO;
using TopStyle_Api.Domain.Entities;
using TopStyle_Api.Domain.Identity;

namespace TopStyle_Api.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> GetUsers();
        Task<ApplicationUser> GetUserById(string id);  // Identity typically uses string for IDs
        Task AddUser(ApplicationUser user, string password);  // Include password if directly handling user creation
        Task<ApplicationUser> UpdateUser(ApplicationUser user);
        Task<bool> DeleteUser(string id);  // It might be more practical to return a bool to indicate success
        Task<ApplicationUser> Register(UserRegisterDTO userRegisterDTO);
        Task<string> Login(UserLoginDTO userLoginDTO);
        Task <bool> IsUserLoggedIn();

        

        //Task<string> GetUserId();
    }
}
