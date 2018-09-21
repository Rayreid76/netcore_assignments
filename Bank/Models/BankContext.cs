using Microsoft.EntityFrameworkCore;

namespace Bank.Models
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options) {}
        public DbSet<Person> Users {get; set;}
        public DbSet<Accounts> Accounts {get; set;}
    }
}