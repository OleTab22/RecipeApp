using System;
using System.Collections.Generic;

namespace RecipeApp2
{
    internal class RecipeManager
    {
        private List<Recipe> _recipes = new List<Recipe>();

        public void AddRecipe(Recipe recipe)
        {
            _recipes.Add(recipe);
        }

        public List<Recipe> GetRecipes()
        {
            return _recipes;
        }

        public Recipe GetRecipeByName(string name)
        {
            return _recipes.Find(recipe => recipe.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void DeleteRecipe(Recipe recipe)
        {
            _recipes.Remove(recipe);
        }

        public void ClearAllRecipes()
        {
            _recipes.Clear();
        }
    }
}
