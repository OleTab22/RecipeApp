using System.Linq;
using System.Windows;
using LiveCharts;
using LiveCharts.Wpf;

namespace RecipeApp
{
    public partial class FilterRecipesWindow : Window
    {
<<<<<<< HEAD
        private RecipeManager _recipeManager;

=======
        // Instance of RecipeManager to manage the recipes
        private RecipeManager _recipeManager;

        // Constructor that initializes the window and sets the RecipeManager instance
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
        public FilterRecipesWindow(RecipeManager recipeManager)
        {
            InitializeComponent();
            _recipeManager = recipeManager;
        }

<<<<<<< HEAD
        // Event handler to manage placeholder text visibility.
=======
        // Event handler to manage placeholder text visibility
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
        private void IngredientFilterTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            PlaceholderTextBlock.Visibility = string.IsNullOrEmpty(IngredientFilterTextBox.Text) ? Visibility.Visible : Visibility.Hidden;
        }

<<<<<<< HEAD
        // Event handler for the Apply Filter button click event.
        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string ingredient = IngredientFilterTextBox.Text;

                // Filter the recipes that contain the specified ingredient (case-insensitive, partial match).
                var filteredRecipes = _recipeManager.GetRecipes()
                    .Where(r => r.Ingredients.Any(i => i.Name.IndexOf(ingredient, StringComparison.OrdinalIgnoreCase) >= 0))
                    .ToList();

                if (filteredRecipes.Any())
                {
                    NoRecipesTextBlock.Visibility = Visibility.Collapsed;

                    // Group the ingredients of the filtered recipes by their food group.
                    var foodGroups = filteredRecipes.SelectMany(r => r.Ingredients).GroupBy(i => i.FoodGroup);
                    SeriesCollection series = new SeriesCollection();

                    // Create a pie chart series for each food group.
                    foreach (var group in foodGroups)
                    {
                        series.Add(new PieSeries
                        {
                            Title = group.Key, // Set the title of the pie slice to the food group name.
                            Values = new ChartValues<int> { group.Count() } // Set the value of the pie slice to the count of ingredients in the group.
                        });
                    }

                    // Update the pie chart with the new series.
                    PieChart.Series = series;
                }
                else
                {
                    // Show a message if no recipes are found.
                    NoRecipesTextBlock.Visibility = Visibility.Visible;
                    PieChart.Series.Clear();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
        }

        // Method to show an error message in a message box.
        private void ShowErrorMessage(Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
=======
        // Event handler for the Apply Filter button click event
        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            // Get the ingredient to filter by from the text box
            string ingredient = IngredientFilterTextBox.Text;

            // Filter the recipes that contain the specified ingredient (case-insensitive, partial match)
            var filteredRecipes = _recipeManager.GetRecipes()
                .Where(r => r.Ingredients.Any(i => i.Name.IndexOf(ingredient, System.StringComparison.OrdinalIgnoreCase) >= 0))
                .ToList();

            // Check if any recipes were found
            if (filteredRecipes.Any())
            {
                NoRecipesTextBlock.Visibility = Visibility.Collapsed;

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
            else
            {
                // Show a message if no recipes are found
                NoRecipesTextBlock.Visibility = Visibility.Visible;
                PieChart.Series.Clear();
            }
        }
    }
}
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
