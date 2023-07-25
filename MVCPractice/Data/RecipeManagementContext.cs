using Microsoft.EntityFrameworkCore;
using MVCPractice.Models;

namespace MVCPractice.Data
{
    public class RecipeManagementContext : DbContext
    {
        public DbSet<RecipeModel> Recipes { get; set; }
        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<IngredientModel> Ingredients { get; set; }

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
                    AuthorId = 1,
                },
                new RecipeModel()
                {
                    Id = 2,
                    Name = "Texas Style Smoked Beef Brisket",
                    CookTime = 900,
                    Description = "Iconic Texas Style brisket. Now yours in only 15 hours!",
                    AuthorId = 2,
                });
            modelBuilder.Entity<AuthorModel>().HasData(
                new AuthorModel()
                {
                    Id = 1,
                    Name = "Erin Clarke",
                    Bio = "Fearlessly dedicated to making healthy food that's affordable, easy-to-make, and best of all DELISH.",
                    Email = "hello@wellplated.com"
                },
                new AuthorModel()
                {
                    Id = 2,
                    Name = "Taylor Shulman",
                    Bio = "Develops recipes professionally, as well as having an extensive cooking history; from attending school to becoming an executive chef.",
                    Email = "Tschul@heygrillhey.com"
                });
            modelBuilder.Entity<IngredientModel>().HasData(
                new IngredientModel()
                {
                    Id = 1,
                    Name = "English Muffin",
                    RecipeId = 1,
                },
                new IngredientModel()
                {
                    Id = 2,
                    Name = "Pepperoni",
                    RecipeId = 1,
                },
                new IngredientModel()
                {
                    Id = 3,
                    Name = "Cheese",
                    RecipeId = 1,
                },
                new IngredientModel()
                {
                    Id = 4,
                    Name = "Banana Pepper",
                    RecipeId = 1,
                },
                new IngredientModel()
                {
                    Id = 5,
                    Name = "Pizza Sauce",
                    RecipeId = 1,
                },
                new IngredientModel()
                {
                    Id = 6,
                    Name = "Olive Oil",
                    RecipeId = 1,
                });
        }
    }
}
