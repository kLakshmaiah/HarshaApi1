using Microsoft.AspNetCore.Identity;

namespace HarshaApi1.Models
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        public string? CompayName { get; set; }
    }
}
