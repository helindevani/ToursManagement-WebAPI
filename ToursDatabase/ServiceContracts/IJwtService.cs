using ToursDatabase.Domain.Identity;
using ToursDatabase.DTO;

namespace ToursDatabase.ServiceContracts
{
    public interface IJwtService
    {
        AuthenticationResponse CreateJwtToken(ApplicationUser user, List<string> roles);
    }
}
