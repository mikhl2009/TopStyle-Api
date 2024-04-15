using System.IdentityModel.Tokens.Jwt;
using TopStyle_Api.Domain.Entities;
using TopStyle_Api.Domain.Identity;

namespace TopStyle_Api.Core.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(string userId);
    }
}
