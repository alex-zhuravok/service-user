using Microsoft.EntityFrameworkCore;
using UserDataAccess.Entities;
 
namespace UserDataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=192.168.101.194;Port=5432;Database=users;Username=admin;Password=admin_pass");
        }
    }
}