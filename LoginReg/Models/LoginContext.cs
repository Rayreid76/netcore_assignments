using Microsoft.EntityFrameworkCore;

namespace LoginReg.Models
{
    public class LoginContext : DbContext
    {
        public LoginContext (DbContextOptions<LoginContext> options) : base(options) { }

        public DbSet<Users> Users {get; set;}
    }
}