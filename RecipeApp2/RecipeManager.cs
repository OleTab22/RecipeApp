using System.Collections.Generic;
using System.Linq;

namespace RecipeApp2
{
    public class RecipeManager
    {
        private readonly List<Recipe> _recipes = new List<Recipe>();

        public void AddRecipe(Recipe recipe)
        {
            _recipes.Add(recipe);
        }

        public List<Recipe> GetRecipes()
        {
            return _recipes.OrderBy(r => r.Name).ToList();
        }

        public List<Recipe> SearchRecipesByName(string name)
        {
            return _recipes.Where(r => r.Name.Contains(name, System.StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
