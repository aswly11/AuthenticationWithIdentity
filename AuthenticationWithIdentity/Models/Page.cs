using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AuthenticationWithIdentity.Models
{
    public class Page
    {
        [Key]

        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<PageAction> PageActions { get; set; }
    }
}
