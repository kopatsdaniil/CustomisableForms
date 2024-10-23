using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CustomisableForms.Models;

namespace CustomisableForms.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Form> Forms { get; set; } = default!;
        public DbSet<Answer> Answers { get; set; } = default!;
    }
}
