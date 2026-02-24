using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportTicketManagement.Data;
using SupportTicketManagement.DTOs.TicketDTOs;
using SupportTicketManagement.Model;

namespace SupportTicketManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public TicketController(AppDbContext dbContext)
        {
            _dbContext = dbContext;

        }


        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            try
            {
                var Ticket = await _dbContext.Tickets
                    .Select(t => new TicketGetDTO
                    {
                        TicketID = t.TicketID,
                        Title = t.Title,
                        Description = t.Description,
                        Status = t.Status,
                        Priority = t.Priority,
                        CreatedBy = t.CreatedBy,
                        AssignTo = t.AssignTo,
                        CreatedAt = t.CreatedAt
                    }).ToListAsync();
                return Ok(Ticket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error getting Tickets", error = ex.Message });
            }
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                var Ticket = await _dbContext.Tickets.FindAsync(id);
                if (Ticket == null)
                {
                    return NotFound(new { message = "Ticket Not Found" });
                }
                return Ok(Ticket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error Getting Ticket", error = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddTicket(TicketAddDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var Ticket = new Tickets
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    Status = dto.Status,
                    Priority = dto.Priority,
                    CreatedBy = dto.CreatedBy,
                    AssignTo = dto.AssignTo,
                    CreatedAt = DateTime.Now
                };

                _dbContext.Tickets.Add(Ticket);
                await _dbContext.SaveChangesAsync();

                return Created("Ticket Added !!!", Ticket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error creating Ticket", error = ex.Message });
            }
        }

        [HttpPatch("Assign/{id}")]
        public async Task<IActionResult> AssignTicket(int id, TicketAssignDTO dto)
        {
            try
            {
                var Ticket = await _dbContext.Tickets.FindAsync(id);
                if (Ticket == null)
                {
                    return NotFound(new { message = "Ticket not found" });
                }

                Ticket.AssignTo = dto.AssignTo;

                await _dbContext.SaveChangesAsync();
                return Ok(Ticket);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error updating Ticket", error = ex.Message });
            }
        }

        [HttpPatch("Status/{id}")]
        public async Task<IActionResult> UpdateTicketStatus(int id, TicketStatusDTO dto)
        {
            try
            {
                var Ticket = await _dbContext.Tickets.FindAsync(id);
                if (Ticket == null)
                {
                    return NotFound(new { message = "Ticket not found" });
                }

                Ticket.Status = dto.Status;

                await _dbContext.SaveChangesAsync();
                return Ok(Ticket);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error updating Ticket", error = ex.Message });
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            try
            {
                var Ticket = await _dbContext.Tickets.FindAsync(id);
                if (Ticket == null)
                {
                    return NotFound(new { message = "user not found" });

                }
                _dbContext.Tickets.Remove(Ticket);
                await _dbContext.SaveChangesAsync();

                return Ok(new { message = "Ticket deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error deleting Ticket", error = ex.Message });
            }
        }

    }
}
