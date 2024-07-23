using System.Windows;

namespace RecipeApp
{
    public partial class MainWindow : Window
    {
        // Instance of RecipeManager to manage the recipes
        private RecipeManager _recipeManager = new RecipeManager();

<<<<<<< HEAD
        // Constructor to initialize the MainWindow
=======
        // Constructor that initializes the main window
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
        public MainWindow()
        {
            InitializeComponent();
        }

<<<<<<< HEAD
        // Event handler for the Create New Recipe button click event
        private void CreateNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Open the CreateRecipeWindow and pass the RecipeManager instance
            OpenWindow(() => new CreateRecipeWindow(_recipeManager));
        }

        // Event handler for the View All Recipes button click event
        private void ViewAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the list of recipes from the RecipeManager
                var recipes = _recipeManager.GetRecipes();
                // Set the ItemSource of RecipeListView to the list of recipes
                RecipeListView.ItemsSource = recipes;
                // If there are no recipes, show an information message
                if (recipes.Count == 0)
                {
                    MessageBox.Show("No recipes available.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                // Show an error message if an exception occurs
                ShowErrorMessage(ex);
            }
        }

        // Event handler for the Filter Recipes button click event
        private void FilterRecipes_Click(object sender, RoutedEventArgs e)
        {
            // Open the FilterRecipesWindow and pass the RecipeManager instance
            OpenWindow(() => new FilterRecipesWindow(_recipeManager));
        }

        // Method to open a new window and handle exceptions
        private void OpenWindow(Func<Window> createWindow)
        {
            try
            {
                // Create and show the new window
                var window = createWindow();
                window.Show();
            }
            catch (Exception ex)
            {
                // Show an error message if an exception occurs
                ShowErrorMessage(ex);
            }
        }

        // Method to show an error message in a message box
        private void ShowErrorMessage(Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
=======
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
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
