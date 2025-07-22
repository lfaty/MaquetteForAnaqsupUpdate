using Microsoft.AspNetCore.Identity;

namespace MaquetteForAnaqsup.API.Identity.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
