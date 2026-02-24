using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SupportTicketManagement.Data;
using SupportTicketManagement.DTOs.Login;
using SupportTicketManagement.Model;
using SupportTicketManagement.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace SupportTicketManagement.Controllers
{


    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthController(AppDbContext context,
            IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            var user = _context.Users
                .FirstOrDefault(x =>
                    x.Email == dto.Email &&
                    x.Password == dto.Password);

            if (user == null)
                return Unauthorized(new
                {
                    status = false,
                    message = "Invalid credentials"
                });

            var key = Encoding.UTF8.GetBytes(
                _config["Jwt:Key"]);

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(1),
                signingCredentials:
                    new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256));

            return Ok(new
            {

                status = true,
                token =
                    new JwtSecurityTokenHandler()
                        .WriteToken(token)
            });
        }
    }

}




