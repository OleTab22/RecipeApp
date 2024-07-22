using System.Linq;
using System.Windows;
using LiveCharts;
using LiveCharts.Wpf;

namespace RecipeApp
{
    public partial class FilterRecipesWindow : Window
    {
        // Instance of RecipeManager to manage the recipes
        private RecipeManager _recipeManager;

        // Constructor that initializes the window and sets the RecipeManager instance
        public FilterRecipesWindow(RecipeManager recipeManager)
        {
            InitializeComponent();
            _recipeManager = recipeManager;
        }

        // Event handler for the Apply Filter button click event
        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            // Get the ingredient to filter by from the text box
            string ingredient = IngredientFilterTextBox.Text;

            // Filter the recipes that contain the specified ingredient (case-insensitive)
            var filteredRecipes = _recipeManager.GetRecipes()
                .Where(r => r.Ingredients.Any(i => i.Name.Equals(ingredient, System.StringComparison.OrdinalIgnoreCase)))
                .ToList();

            // Group the ingredients of the filtered recipes by their food group
            var foodGroups = filteredRecipes.SelectMany(r => r.Ingredients).GroupBy(i => i.FoodGroup);
            SeriesCollection series = new SeriesCollection();

            // Create a pie chart series for each food group
            foreach (var group in foodGroups)
            {
                series.Add(new PieSeries
                {
                    Title = group.Key, // Set the title of the pie slice to the food group name
                    Values = new ChartValues<int> { group.Count() } // Set the value of the pie slice to the count of ingredients in the group
                });
            }

            // Update the pie chart with the new series
            PieChart.Series = series;
        }
    }
}
