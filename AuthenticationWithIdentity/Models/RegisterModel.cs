using System.ComponentModel.DataAnnotations;

namespace AuthenticationWithIdentity.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        public string Password { get; set; }

    }
}
