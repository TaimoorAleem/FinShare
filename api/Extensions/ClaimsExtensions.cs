using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Server.Extensions
{
    public static class ClaimsExtensions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user.Claims.SingleOrDefault(XmlConfigurationExtensions => XmlConfigurationExtensions.Type.Equals("https://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")).Value;
        }
    }
}
