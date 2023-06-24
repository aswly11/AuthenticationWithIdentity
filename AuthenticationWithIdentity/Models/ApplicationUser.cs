using Microsoft.AspNetCore.Identity;

namespace AuthenticationWithIdentity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int IsAdmin { get; set; }
    }
}
