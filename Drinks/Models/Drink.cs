using Drinks.DBContexts;
using System.ComponentModel.DataAnnotations;

namespace Drinks.Models
{
    public class Drink
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<int> IngredientIds { get; set; }
        public double Price
        {
            get
            {
                double cost = 0;
                using (var context = new DrinksContext())
                {
                    foreach (var id in IngredientIds)
                    {
                        var i = context.Ingredients.FirstOrDefault(o => o.Id == id);
                        if (i != null)
                            cost += i.Cost;
                    }
                }
                return cost;
            }
        }
        public Drink()
        {

        }

        public Drink(string name, List<int> ingredientIds)
        {
            Name = name;
            IngredientIds = new List<int>();
            foreach (var id in ingredientIds)
            {
                IngredientIds.Add(id);
            }
        }

        public void AddIngredient(int ingredientId)
        {
            IngredientIds.Add(ingredientId);
        }
        public void NewRecipee(List<int> ingredientIds)
        {
            IngredientIds.Clear();
            foreach (var id in ingredientIds)
            {
                IngredientIds.Add(id);
            }
        }
    }
}
