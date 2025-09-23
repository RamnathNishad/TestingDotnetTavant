using Microsoft.EntityFrameworkCore;
using UnitTestControllerDemo.Models;

namespace UnitTestControllerDemo.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options) 
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseInMemoryDatabase(databaseName: "UserDb");
        }
        public DbSet<User> Users { get; set; }
    }
}
