using System.Collections.Generic;
using System.Windows;

namespace RecipeApp
{
    public partial class CreateRecipeWindow : Window
    {
        // Instance of RecipeManager to manage the recipes
        private RecipeManager _recipeManager;

        // Constructor that initializes the window and sets the RecipeManager instance
        public CreateRecipeWindow(RecipeManager recipeManager)
        {
            InitializeComponent();
            _recipeManager = recipeManager;
        }

        // Event handler for the Add Recipe button click event
        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Get the recipe name from the text box
            string name = RecipeNameTextBox.Text;

            // Initialize empty lists for ingredients and steps
            var ingredients = new List<Ingredient>();
            var steps = new List<string>();

            // Create a new Recipe object with the provided name, ingredients, and steps
            var recipe = new Recipe(name, ingredients, steps);

            // Add the new recipe to the RecipeManager
            _recipeManager.AddRecipe(recipe);

            // Show a message box to inform the user that the recipe was added successfully
            MessageBox.Show("Recipe added successfully!");

            // Close the CreateRecipeWindow
            this.Close();
        }
    }
}
