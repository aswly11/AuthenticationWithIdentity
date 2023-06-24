using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AuthenticationWithIdentity.Models
{
    public class PageAction
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Page")]
        public int PageId { get; set; }
        public virtual Page? Page { get; set; }
    }
}
