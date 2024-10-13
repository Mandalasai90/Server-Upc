using System.Security.Claims;

namespace UrbanPoshAPIApp.UrbanServices
{
    public class AuthorizationService
    {
        public bool AuthorizeClaim(ClaimsPrincipal user, string claimType, string claimValue)
        {
            return user.HasClaim(claimType, claimValue);
        }
    }

}
