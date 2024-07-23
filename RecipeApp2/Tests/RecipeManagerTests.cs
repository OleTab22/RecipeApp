using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeApp2;
using System;
using System.Collections.Generic;

namespace RecipeApp2.Tests
{
    [TestClass]
    public class RecipeManagerTests
    {
        private RecipeManager _manager;

        [TestInitialize]
        public void Setup()
        {
            _manager = new RecipeManager();
        }

        [TestMethod]
        public void TestAddRecipe()
        {
            var ingredients = new List<Ingredient>
            {
                new Ingredient("Flour", 1, "cup", 100, "Grain"),
                new Ingredient("Sugar", 0.5, "cup", 200, "Sweetener")
            };
            var steps = new List<string> { "Mix ingredients", "Bake for 30 minutes" };
            var recipe = new Recipe("Cake", ingredients, steps);

            _manager.AddRecipe(recipe);
            var recipes = _manager.GetRecipes();

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

        [TestMethod]
        public void TestDeleteRecipe()
        {
            var recipe = new Recipe("Test Recipe");

            _manager.AddRecipe(recipe);
            _manager.DeleteRecipe(recipe);

            Assert.AreEqual(0, _manager.GetRecipes().Count);
        }

        [TestMethod]
        public void TestClearAllRecipes()
        {
            _manager.AddRecipe(new Recipe("Test Recipe 1"));
            _manager.AddRecipe(new Recipe("Test Recipe 2"));

            _manager.ClearAllRecipes();

            Assert.AreEqual(0, _manager.GetRecipes().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetRecipeByName_EmptyName_ThrowsException()
        {
            _manager.GetRecipeByName("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestDeleteRecipe_NullRecipe_ThrowsException()
        {
            _manager.DeleteRecipe(null);
        }

        [TestMethod]
        public void TestGetRecipeByName_NotFound()
        {
            var recipe = _manager.GetRecipeByName("Nonexistent Recipe");
            Assert.IsNull(recipe);
        }

        [TestMethod]
        public void TestAddRecipe_NullRecipe_ThrowsException()
        {
            try
            {
                _manager.AddRecipe(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Recipe cannot be null (Parameter 'recipe')", ex.Message);
                throw;
            }
        }

        [TestMethod]
        public void TestDeleteRecipe_NotFound_ThrowsException()
        {
            var recipe = new Recipe("Nonexistent Recipe");
            try
            {
                _manager.DeleteRecipe(recipe);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Recipe not found (Parameter 'recipe')", ex.Message);
                throw;
            }
        }
    }
}