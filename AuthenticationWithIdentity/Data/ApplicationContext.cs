using AuthenticationWithIdentity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationWithIdentity.Data
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
      : base(options)
        {
        }
        DbSet<ApplicationUser> Users { get; set; }
    }
}
