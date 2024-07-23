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