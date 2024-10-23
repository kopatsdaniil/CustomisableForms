using Microsoft.AspNetCore.Identity;

namespace CustomisableForms.Models
{
    public class ApplicationUser : IdentityUser
    {
        public required IList<Form> Forms { get; set; }
    }
}
