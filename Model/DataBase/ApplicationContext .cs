using Microsoft.EntityFrameworkCore;
 
namespace BlazorApp_ml.NET
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
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=university;Trusted_Connection=True;");
        }
    }
}