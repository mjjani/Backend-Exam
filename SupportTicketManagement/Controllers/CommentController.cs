using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportTicketManagement.Data;
using SupportTicketManagement.DTOs.TicketCommentsDTOs;
using SupportTicketManagement.DTOs.TicketDTOs;
using SupportTicketManagement.Model;

namespace SupportTicketManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public CommentController(AppDbContext dbContext)
        {
            _dbContext = dbContext;

        }


        [HttpGet]
        public async Task<IActionResult> GetAllTicketComments()
        {
            try
            {
                var Comment = await _dbContext.TicketComments
                    .Select(t => new TicketCommentsGetDTO
                    {
                        CommentID = t.CommentID,
                        TicketID = t.TicketID,
                        UserID = t.UserID,
                        User = t.User.Name,
                        Comment = t.Comment,
                        CreatedAt = t.CreatedAt
                    }).ToListAsync();
                return Ok(Comment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error getting Comments", error = ex.Message });
            }
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                var comments = await _dbContext.TicketComments.FindAsync(id);
                if (comments == null)
                {
                    return NotFound(new { message = "Comment Not Found" });
                }
                return Ok(comments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error Getting Comment", error = ex.Message });
            }
        }


        [HttpPost("{id}")]
        public async Task<IActionResult> AddTicketComments(int id ,TicketCommentsAddDTO dto)
        {
            try
            {
                var Ticket = await _dbContext.Tickets.FindAsync(id);
                if (Ticket == null)
                {
                    return NotFound(new { message = "Ticket not found" });
                }

                var Comment = new TicketComments
                {
                    Comment = dto.Comment,
                    CreatedAt = DateTime.Now
                };

                await _dbContext.SaveChangesAsync();
                

                return Created("TicketComment Added !!!", Comment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error creating TicketComment", error = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpadateTicketComment(int id, TicketCommentsAddDTO dto)
        {
            try
            {
                var Comment = await _dbContext.TicketComments.FindAsync(id);
                if (Comment == null)
                {
                    return NotFound(new { message = "Ticket not found" });
                }

                Comment.Comment = dto.Comment;

                await _dbContext.SaveChangesAsync();
                return Ok(Comment);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error updating TicketComment", error = ex.Message });
            }
        }

        

        [HttpDelete]
        public async Task<IActionResult> DeleteTicketComment(int id)
        {
            try
            {
                var Comment = await _dbContext.TicketComments.FindAsync(id);
                if (Comment == null)
                {
                    return NotFound(new { message = "Comment not found" });

                }
                _dbContext.TicketComments.Remove(Comment);
                await _dbContext.SaveChangesAsync();

                return Ok(new { message = "TicketComment deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error deleting TicketComment", error = ex.Message });
            }
        }
    }
}
