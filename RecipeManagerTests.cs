using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeApp2;

namespace RecipeApp2.Tests
{
    [TestClass]
    public class RecipeManagerTests
    {
        [TestMethod]
        public void TestAddRecipe()
        {
            // Arrange
            var recipeManager = new RecipeManager();
            var recipe = new Recipe("Test Recipe");

            // Act
            recipeManager.AddRecipe(recipe);

            // Assert
            Assert.AreEqual(1, recipeManager.GetRecipes().Count);
        }

        [TestMethod]
        public void TestGetRecipeByName()
        {
            // Arrange
            var recipeManager = new RecipeManager();
            var recipe = new Recipe("Test Recipe");
            recipeManager.AddRecipe(recipe);

            // Act
            var retrievedRecipe = recipeManager.GetRecipeByName("Test Recipe");

            // Assert
            Assert.IsNotNull(retrievedRecipe);
            Assert.AreEqual("Test Recipe", retrievedRecipe.Name);
        }

        [TestMethod]
        public void TestDeleteRecipe()
        {
            // Arrange
            var recipeManager = new RecipeManager();
            var recipe = new Recipe("Test Recipe");
            recipeManager.AddRecipe(recipe);

            // Act
            recipeManager.DeleteRecipe(recipe);

            // Assert
            Assert.AreEqual(0, recipeManager.GetRecipes().Count);
        }

        [TestMethod]
        public void TestClearAllRecipes()
        {
            // Arrange
            var recipeManager = new RecipeManager();
            var recipe1 = new Recipe("Test Recipe 1");
            var recipe2 = new Recipe("Test Recipe 2");
            recipeManager.AddRecipe(recipe1);
            recipeManager.AddRecipe(recipe2);

            // Act
            recipeManager.ClearAllRecipes();

            // Assert
            Assert.AreEqual(0, recipeManager.GetRecipes().Count);
        }
    }
}
