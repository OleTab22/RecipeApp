using System.Collections.Generic;
using System.Windows;

namespace RecipeApp
{
    public partial class CreateRecipeWindow : Window
    {
        private RecipeManager _recipeManager;

        public CreateRecipeWindow(RecipeManager recipeManager)
        {
            InitializeComponent();
            _recipeManager = recipeManager;
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            string name = RecipeNameTextBox.Text;
            // Collect ingredients and steps
            var ingredients = new List<Ingredient>();
            var steps = new List<string>();

            var recipe = new Recipe(name, ingredients, steps);
            _recipeManager.AddRecipe(recipe);
            MessageBox.Show("Recipe added successfully!");
            this.Close();
        }
    }
}
