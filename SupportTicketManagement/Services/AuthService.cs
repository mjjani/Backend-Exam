using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SupportTicketManagement.Data;
using SupportTicketManagement.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SupportTicketManagement.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        // Generate JWT Token
        public string GenerateJwtToken(Users user)
        {
            var jwtSettings = _configuration.GetSection("Jwt");

            // Create secret key
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings["Key"])
            );

            // Signing credentials uses Hash-based Message Authentication Code
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Add claims (user info inside token)
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.RoleName),
                new Claim("UserID", user.UserID.ToString())
            };


            // Token expiry time
            var expiryMinutes = Convert.ToDouble(jwtSettings["TokenExpiryMinutes"]);

            // Create token
            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(expiryMinutes),
                signingCredentials: creds
            );

            // Return token string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // Login Logic
        public async Task<object> LoginAsync(string email, string password)
        {
            var User = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (User == null)
                return null;

            var token = GenerateJwtToken(User);

            return new
            {
                token,
                User = new
                {
                    User.UserID,
                    User.Email,
                    User.Role
                }
            };
        }
    }
}
