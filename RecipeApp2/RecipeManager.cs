<<<<<<< HEAD
using System;
using System.Collections.Generic;

namespace RecipeApp2
{
    internal class RecipeManager
    {
        private List<Recipe> _recipes = new List<Recipe>();

        // Adds a new recipe to the list
        public void AddRecipe(Recipe recipe)
        {
            if (recipe == null)
                throw new ArgumentNullException(nameof(recipe), "Recipe cannot be null");

            _recipes.Add(recipe);
        }

        // Retrieves all recipes
        public List<Recipe> GetRecipes()
        {
            return _recipes;
        }

        // Retrieves a recipe by its name
        public Recipe GetRecipeByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));

            return _recipes.Find(recipe => recipe.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        // Deletes a specified recipe
        public void DeleteRecipe(Recipe recipe)
        {
            if (recipe == null)
                throw new ArgumentNullException(nameof(recipe), "Recipe cannot be null");

            if (!_recipes.Remove(recipe))
                throw new ArgumentException("Recipe not found", nameof(recipe));
        }

        // Clears all recipes
        public void ClearAllRecipes()
        {
            _recipes.Clear();
        }
    }
}
=======
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp2
{
    // The RecipeManager class is responsible for managing a collection of recipes.
    // It provides methods to add new recipes, retrieve all recipes, and search for recipes by name.
    public class RecipeManager
    {
        // A private list to store the recipes.
        private readonly List<Recipe> _recipes = new List<Recipe>();

        // Adds a new recipe to the collection.
        // Parameters:
        //   recipe - The Recipe object to be added to the collection.
        public void AddRecipe(Recipe recipe)
        {
            _recipes.Add(recipe); // Add the provided recipe to the list.
        }

        // Retrieves all recipes in the collection, ordered by their name.
        // Returns:
        //   A list of Recipe objects, sorted alphabetically by their name.
        public List<Recipe> GetRecipes()
        {
            return _recipes.OrderBy(r => r.Name).ToList(); // Return the list of recipes, sorted by name.
        }

        // Searches for recipes by their name.
        // Parameters:
        //   name - The name (or partial name) to search for.
        // Returns:
        //   A list of Recipe objects whose names contain the provided search term, case-insensitive.
        public List<Recipe> SearchRecipesByName(string name)
        {
            return _recipes.Where(r => r.Name.Contains(name, System.StringComparison.OrdinalIgnoreCase)).ToList(); // Return the list of recipes that match the search term.
        }
    }
}
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
