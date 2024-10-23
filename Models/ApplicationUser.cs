using Microsoft.AspNetCore.Identity;

namespace CustomisableForms.Models
{
    public class ApplicationUser : IdentityUser
    {
        public required IList<Form> Forms { get; set; }

        public required IList<Answer> Answers { get; set; }
    }
}
