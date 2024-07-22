using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    // The RecipeManager class is responsible for managing a collection of recipes.
    // It provides methods to add new recipes, retrieve all recipes, and search for recipes by name.
    public class RecipeManager
    {
        // A private list to store the recipes.
        private readonly List<Recipe> _recipes = new List<Recipe>();

        // Adds a new recipe to the list of recipes.
        // Parameters:
        //   recipe - The Recipe object to be added to the list.
        public void AddRecipe(Recipe recipe)
        {
            _recipes.Add(recipe);
        }

        // Retrieves all recipes, ordered by their name in ascending order.
        // Returns:
        //   A list of Recipe objects, sorted by name.
        public List<Recipe> GetRecipes()
        {
            return _recipes.OrderBy(r => r.Name).ToList();
        }

        // Searches for recipes by their name, ignoring case.
        // Parameters:
        //   name - The name or partial name to search for.
        // Returns:
        //   A list of Recipe objects that contain the specified name.
        public List<Recipe> SearchRecipesByName(string name)
        {
            return _recipes.Where(r => r.Name.Contains(name, System.StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
