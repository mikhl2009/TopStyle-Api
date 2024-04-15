using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TopStyle_Api.Extentions
{
    public static class JwtExtenstions
    {
        public static IServiceCollection AddJwtExtension(this IServiceCollection services, IConfiguration configuration)
        {
            string issuer = configuration["JwtConfig:Issuer"];
            string audience = configuration["JwtConfig:Audience"];
            string secret = configuration["JwtConfig:Secret"];

            if (string.IsNullOrWhiteSpace(issuer) || string.IsNullOrWhiteSpace(audience) || string.IsNullOrWhiteSpace(secret))
            {
                throw new InvalidOperationException("JWT settings are not properly configured in the app settings.");
            }

            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt => {
                opt.SaveToken = true;
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
                };
            });

            return services;
        }



    }
}
