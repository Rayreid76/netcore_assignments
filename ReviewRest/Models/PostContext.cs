using Microsoft.EntityFrameworkCore;
 
namespace ReviewRest.Models
{
    public class PostContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public PostContext(DbContextOptions<PostContext> options) : base(options) { }
        public DbSet<User> Users {get; set;}
    }
}
