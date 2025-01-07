using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BankApp.Api.Extensions
{
    public static class AuthExtensions
    {
        public static IServiceCollection AddAuth(this IServiceCollection services)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
             {
                 opt.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = "https://localhost:7214/",
                     ValidAudience = "https://localhost:7214/",
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("fkls5235k325bb25b23blb52352b35235b2b532knels"))
                 };

             });

            return services;
        }
    }
}
