using Microsoft.EntityFrameworkCore;

namespace WeddingPlan.Models
{
    public class WeddingContext : DbContext
    {
        public WeddingContext(DbContextOptions<WeddingContext> options) : base(options) {}
        public DbSet<WeddingGoer> users {get; set;}
        public DbSet<Planner> planner {get; set;}
        public DbSet<Response> Responses {get; set;}
        
    }
}