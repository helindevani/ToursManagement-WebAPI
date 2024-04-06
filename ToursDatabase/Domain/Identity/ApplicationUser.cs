using Microsoft.AspNetCore.Identity;

namespace ToursDatabase.Domain.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? PersonName { get; set; }
    }
}
