using Microsoft.AspNetCore.Identity;

namespace FitnessApp.Infrastructure.Identity;

public class AppUser : IdentityUser
{
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    
    public DateTime? UpdatedAtUtc { get; set; }
}