using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using TopStyle_Api.Data.Interfaces;
using TopStyle_Api.Domain.Identity;
using Microsoft.AspNetCore.Mvc;

public class UserRepo : IUserRepo
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserRepo(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public Task AddUser(ApplicationUser user, string password)
    {
        var result = _userManager.CreateAsync(user, password);
        if (result.Result.Succeeded)
        {
            return Task.CompletedTask;
        }
        throw new System.Exception("User creation failed.");
    }

    public async Task<bool> DeleteUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }
        return false;
    }

    public async Task<ApplicationUser> GetUserById(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return user;
    }

    public async Task<IEnumerable<ApplicationUser>> GetUsers()
    {
        var users = _userManager.Users.ToList();
        return users;
    }

    public async Task<ApplicationUser> UpdateUser(ApplicationUser user)
    {
        var existingUser = await _userManager.FindByIdAsync(user.Id);
        if (existingUser != null)
        {
            existingUser.Email = user.Email;
            existingUser.UserName = user.UserName;

            var result = await _userManager.UpdateAsync(existingUser);
            if (result.Succeeded)
            {
                return existingUser;
            }
        }
        throw new System.Exception("User not found or update failed.");
    }
}
