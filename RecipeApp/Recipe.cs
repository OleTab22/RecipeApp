using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
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