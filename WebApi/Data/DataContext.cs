using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    // datacontext ärver från dbcontext, importerar från EFC
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // skapar tabeller i DB, ger tabellen ett namn (Products), vill jag ha fler tabeller lägger jag det här
        public DbSet<Products> Products { get; set; }

        // Kopplar Products till en container som heter Products
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().ToContainer("Products").HasPartitionKey(x => x.Id);
        }
    }
}
