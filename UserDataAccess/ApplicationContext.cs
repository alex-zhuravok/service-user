using Microsoft.EntityFrameworkCore;
using UserDataAccess.Entities;
using UserDataAccess.Interfaces;

namespace UserDataAccess
{
    public class ApplicationContext : DbContext, IDBContext
    {
        public DbSet<User> Users { get; set; }
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseNpgsql("Host=192.168.101.194;Port=5432;Database=users;Username=admin;Password=admin_pass");
        // }
    }
}