using Microsoft.AspNetCore.Identity;


namespace FinalProject.Models
{
    public class AppUserTokens : IdentityUserToken<string>
    {
        public DateTime ExpireDate { get; set; }
    }
}
