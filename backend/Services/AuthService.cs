using backend.Models;
using backend.Models.Data;
using backend.Models.Dto;
using backend.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend.Services
{
    public class AuthService(IConfiguration config, AppDbContext context) : IAuthService
    {
        private readonly IConfiguration _config = config;
        private readonly AppDbContext _context = context;

        public string? Authenticate(AuthDto authDto)
        {
            User? user = _context.Users.FirstOrDefault(x => x.Username == authDto.UsernameOrEmail);
            user = user == null ? _context.Users.FirstOrDefault(x => x.Email == authDto.UsernameOrEmail) : user;

            if (user == null)
                return null;
            if (!BCrypt.Net.BCrypt.Verify(authDto.Password, user.PasswordHash))
                return null;
            return GenerateJWTToken(user);
        }

        public string? GenerateJWTToken(User user)
        {
            var jwtSettings = _config.GetSection("Jwt");
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim("Id", user.Id.ToString()),
                new Claim("Role", user.RoleId.ToString()) // sets the role
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(jwtSettings["Exp"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
