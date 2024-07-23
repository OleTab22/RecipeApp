using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    // The Recipe class represents a recipe which includes a name, a list of ingredients, and a list of steps to prepare the recipe.
    public class Recipe
    {
        // The name of the recipe (e.g., "Chocolate Cake").
        public string Name { get; set; }

        // A list of ingredients required for the recipe.
        public List<Ingredient> Ingredients { get; set; }

        // A list of steps to follow in order to prepare the recipe.
        public List<string> Steps { get; set; }

        // Constructor to initialize a Recipe object with the provided name, ingredients, and steps.
        // Parameters:
        //   name - The name of the recipe.
        //   ingredients - A list of ingredients required for the recipe.
        //   steps - A list of steps to follow in order to prepare the recipe.
        public Recipe(string name, List<Ingredient> ingredients, List<string> steps)
        {
            Name = name;
            Ingredients = ingredients;
            Steps = steps;
        }

        // A property to calculate the total number of calories in the recipe by summing up the calories of each ingredient.
        public int TotalCalories => Ingredients.Sum(i => i.Calories);
    }
}
