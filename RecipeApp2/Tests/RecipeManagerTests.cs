using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeApp2;
using System.Collections.Generic;

namespace RecipeApp2.Tests
{
    [TestClass]
    public class RecipeManagerTests
    {
        [TestMethod]
        public void TestAddRecipe()
        {
            var manager = new RecipeManager();
            var ingredients = new List<Ingredient>
            {
                new Ingredient("Flour", 1, "cup", 100, "Grain"),
                new Ingredient("Sugar", 0.5, "cup", 200, "Sweetener")
            };
            var steps = new List<string> { "Mix ingredients", "Bake for 30 minutes" };
            var recipe = new Recipe("Cake", ingredients, steps);

            manager.AddRecipe(recipe);
            var recipes = manager.GetRecipes();

            Assert.AreEqual(1, recipes.Count);
            Assert.AreEqual("Cake", recipes[0].Name);
        }

        [TestMethod]
        public void TestTotalCalories()
        {
            var ingredients = new List<Ingredient>
            {
                new Ingredient("Flour", 1, "cup", 100, "Grain"),
                new Ingredient("Sugar", 0.5, "cup", 200, "Sweetener")
            };
            var steps = new List<string> { "Mix ingredients", "Bake for 30 minutes" };
            var recipe = new Recipe("Cake", ingredients, steps);

            Assert.AreEqual(300, recipe.TotalCalories);
        }
    }
}
