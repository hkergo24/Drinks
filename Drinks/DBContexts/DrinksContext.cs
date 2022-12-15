using Microsoft.EntityFrameworkCore;
using Drinks.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace Drinks.DBContexts
{
    public class DrinksContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DrinksContext()
        {

        }
        public DrinksContext(DbContextOptions<DrinksContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DrinksDB");
        optionsBuilder.UseSqlServer(connectionString);
    }

    public DbSet<Drink> Drinks { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Ingredient>().HasData(
           new Ingredient(1, "Cafe", 1),
           new Ingredient(2, "Sucre", 0.1),
           new Ingredient(3, "Creme", 0.5),
           new Ingredient(4, "The", 2),
           new Ingredient(5, "Eau", 0.2),
           new Ingredient(6, "Chocolat", 1),
           new Ingredient(7, "Lait", 0.4)
       );

        modelBuilder.Entity<Drink>()
.Property(b => b.IngredientIds)
.HasConversion(
v => JsonConvert.SerializeObject(v),
v => JsonConvert.DeserializeObject<List<int>>(v));

        modelBuilder.Entity<Drink>().HasData(
             new Drink
             {
                 Id = 1,
                 Name = "Expresso",
                 IngredientIds = new List<int>() { 1, 5 }
             },
             new Drink
             {
                 Id = 2,
                 Name = "Allongé",
                 IngredientIds = new List<int>() { 1, 5, 5 }
             },
             new Drink
             {
                 Id = 3,
                 Name = "Capuccino",
                 IngredientIds = new List<int>() { 1, 3, 5, 6 }
             },
             new Drink
             {
                 Id = 4,
                 Name = "Chocolat",
                 IngredientIds = new List<int>() { 2, 5, 6, 6, 6, 7, 7 }
             },
             new Drink
             {
                 Id = 5,
                 Name = "The",
                 IngredientIds = new List<int>() { 5, 5, 4 }
             }
        );
    }


}
}
