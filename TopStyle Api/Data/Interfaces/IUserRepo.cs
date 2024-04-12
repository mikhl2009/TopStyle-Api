using TopStyle_Api.Domain.Entities;
using TopStyle_Api.Domain.Identity;

namespace TopStyle_Api.Data.Interfaces
{
    public interface IUserRepo
    {
        Task<IEnumerable<ApplicationUser>> GetUsers();
        Task<ApplicationUser> GetUserById(string userId);
        Task AddUser(ApplicationUser user, string password);
        Task<ApplicationUser> UpdateUser(ApplicationUser user);
        Task<bool> DeleteUser(string userId); 
    }
}
