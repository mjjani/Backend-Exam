using SupportTicketManagement.Model;

namespace SupportTicketManagement.Services
{
    public interface IAuthService
    {
        Task<object> LoginAsync(string EmailOrMobile, string password);
        string GenerateJwtToken(Users user);
    }
}
