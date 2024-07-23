using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
<<<<<<< HEAD
    /// <summary>
    /// Represents a recipe which includes a name, a list of ingredients, and a list of steps.
    /// </summary>
    public class Recipe
    {
        /// <summary>
        /// Gets or sets the name of the recipe.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of ingredients required for the recipe.
        /// </summary>
        public List<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// Gets or sets the list of steps to follow in order to prepare the recipe.
        /// </summary>
        public List<string> Steps { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Recipe"/> class.
        /// </summary>
        /// <param name="name">The name of the recipe.</param>
        /// <param name="ingredients">The list of ingredients required for the recipe.</param>
        /// <param name="steps">The list of steps to follow in order to prepare the recipe.</param>
        public Recipe(string name, List<Ingredient> ingredients, List<string> steps)
        {
            // Validate that the name is not empty or whitespace.
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));

            Name = name;
            Ingredients = ingredients ?? new List<Ingredient>();
            Steps = steps ?? new List<string>();
        }

        /// <summary>
        /// Calculates the total number of calories in the recipe by summing up the calories of each ingredient.
        /// </summary>
        public int TotalCalories => Ingredients.Sum(i => i.Calories);
    }
}
=======
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
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
