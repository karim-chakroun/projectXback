using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aladin.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "nvarchar(150)")]
        public string? FullName { get; set; }
        public string? Adresse { get; set; }
        public string? AboutMe { get; set; }
        public DateTime? birthday { get; set; }
        public string? Image { get; set; }
    }
}
