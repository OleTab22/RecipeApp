using System.Windows;

namespace RecipeApp
{
    public partial class MainWindow : Window
    {
        // Instance of RecipeManager to manage the recipes
        private RecipeManager _recipeManager = new RecipeManager();

        // Constructor that initializes the main window
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler for the "Create New Recipe" button click event
        private void CreateNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Open the CreateRecipeWindow and pass the RecipeManager instance to it
            var createRecipeWindow = new CreateRecipeWindow(_recipeManager);
            createRecipeWindow.Show();
        }

        // Event handler for the "View All Recipes" button click event
        private void ViewAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            // Set the items source of the RecipeListView to the list of recipes from the RecipeManager
            RecipeListView.ItemsSource = _recipeManager.GetRecipes();
        }

        // Event handler for the "Filter Recipes" button click event
        private void FilterRecipes_Click(object sender, RoutedEventArgs e)
        {
            // Open the FilterRecipesWindow and pass the RecipeManager instance to it
            var filterRecipesWindow = new FilterRecipesWindow(_recipeManager);
            filterRecipesWindow.Show();
        }
    }
}
