using Microsoft.EntityFrameworkCore;
namespace Authentication.Models
{
    public class AuthenticationContext : DbContext
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options) { }
        public DbSet<User>? Users { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
