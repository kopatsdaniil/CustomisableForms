using Microsoft.AspNetCore.Identity;

namespace CustomisableForms.Models
{
    public class ApplicationUser : IdentityUser
    {
        public IList<Form> Forms { get; set; }
    }
}
