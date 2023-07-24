using Microsoft.EntityFrameworkCore;
using MVCPractice.Models;

namespace MVCPractice.Data
{
    public class RecipeManagementContext : DbContext
    {
        public DbSet<RecipeModel> Recipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=RecipeManagement;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeModel>().HasData(
                new RecipeModel()
                {
                    Id = 1,
                    Name = "English Muffin Pizza",
                    CookTime = 15,
                    Description = "Easy english muffin pizzas that are quick and simple to make. Perfect for a quick lunch.",
                },
                new RecipeModel()
                {
                    Id = 2,
                    Name = "Texas Style Smoked Beef Brisket",
                    CookTime = 900,
                    Description = "Iconic Texas Style brisket. Now yours in only 15 hours!",
                });
        }
    }

    
}
