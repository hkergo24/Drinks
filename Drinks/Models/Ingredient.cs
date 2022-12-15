using System.ComponentModel.DataAnnotations;

namespace Drinks.Models
{
    public class Ingredient
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Cost { get; set; }
        public Ingredient(int id, string name, double cost)
        {
            Id = id;
            Name = name;
            Cost = cost;
        }
    }
}
