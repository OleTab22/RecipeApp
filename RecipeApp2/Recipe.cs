using System.Collections.Generic;
using System.Linq;

namespace RecipeApp2
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public Recipe(string name, List<Ingredient> ingredients, List<string> steps)
        {
            Name = name;
            Ingredients = ingredients;
            Steps = steps;
        }

        public int TotalCalories => Ingredients.Sum(i => i.Calories);
    }
}
