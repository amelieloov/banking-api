using BankApp.Core.Interfaces;
using BankApp.Data.Interfaces;
using BankApp.Domain.DTOs;
using BankApp.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BankApp.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepo _repo;

        public UserService(IConfiguration configuration, IUserRepo repo)
        {
            _configuration = configuration;
            _repo = repo;
        }

        public async Task<string> VerifyLoginAsync(UserDTO userDto)
        {
            var user = await _repo.GetUserInfoAsync(userDto.Username);
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            if (user == null || BCrypt.Net.BCrypt.Verify(userDto.Password, user.PasswordHash) == false)
                throw new UnauthorizedAccessException("Invalid login credentials.");

            return GenerateJwtToken(user);
        }

        public string GenerateJwtToken(User user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Role, user.Role.RoleName.ToString())
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: signingCredentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        }
    }
}
