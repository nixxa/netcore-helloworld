using Microsoft.EntityFrameworkCore;
using Models;

namespace Core
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=..\\..\\data\\app.db");
        }
    }
}