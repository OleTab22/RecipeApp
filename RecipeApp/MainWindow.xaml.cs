using System.Windows;

namespace RecipeApp
{
    public partial class MainWindow : Window
    {
        private RecipeManager _recipeManager = new RecipeManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            var createRecipeWindow = new CreateRecipeWindow(_recipeManager);
            createRecipeWindow.Show();
        }

        private void ViewAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            RecipeListView.ItemsSource = _recipeManager.GetRecipes();
        }

        private void FilterRecipes_Click(object sender, RoutedEventArgs e)
        {
            var filterRecipesWindow = new FilterRecipesWindow(_recipeManager);
            filterRecipesWindow.Show();
        }
    }
}
