using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportTicketManagement.Data;
using SupportTicketManagement.DTOs.UserDTOS;
using SupportTicketManagement.Model;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace SupportTicketManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public UserController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var Users = await _dbContext.Users
                    .Select(u => new UserGetDTO
                    {
                        UserID = u.UserID,
                        Name = u.Name,
                        Email = u.Email,
                        Password = u.Password,
                        RoleID = u.RoleID,
                        Role = u.Role.RoleName,
                        CreatedAt = u.CreatedAt
                    }).ToListAsync();
                return Ok(Users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error getting users", error = ex.Message });
            }
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                var User = await _dbContext.Users.FindAsync(id);
                if (User == null)
                {
                    return NotFound(new { message = "User Not Found" });
                }
                return Ok(User);
            }
            catch (Exception ex) 
            { 
                return StatusCode(500, new { message = "Error Getting User", error = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddUser(UserAddDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                bool exists = await _dbContext.Users.AnyAsync(u => u.Email == dto.Email);
                if (exists)
                {
                    return BadRequest(new { message = "User already exists" });
                }

                var User = new Users
                {
                    Name = dto.Username,
                    Email = dto.Email,
                    Password = dto.Password, 
                    RoleID = dto.RoleID,
                    
                    CreatedAt = DateTime.Now
                };

                _dbContext.Users.Add(User);
                await _dbContext.SaveChangesAsync();

                return Created("User Added !!!", User);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error creating user", error = ex.Message });
            }
        }



        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserAddDTO dto)
        {
            try
            {
                var User = await _dbContext.Users.FindAsync(id);
                if (User == null)
                {
                    return NotFound(new { message = "User not found" });
                }
                User.Name = dto.Username ?? User.Name;
                User.Email = dto.Email ?? User.Email;
                if (!string.IsNullOrWhiteSpace(dto.Password))
                {
                    User.Password = dto.Password;
                }
                User.RoleID = dto.RoleID;
               
                await _dbContext.SaveChangesAsync();
                return Ok(User);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error updating user", error = ex.Message });
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var User = await _dbContext.Users.FindAsync(id);
                if(User == null)
                {
                    return NotFound(new { message = "user not found" });

                }
                _dbContext.Users.Remove(User);
                await _dbContext.SaveChangesAsync();

                return Ok(new { message = "User deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error deleting user", error = ex.Message });
            }
        }
    }
}
