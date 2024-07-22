using System.Linq;
using System.Windows;
using LiveCharts;
using LiveCharts.Wpf;

namespace RecipeApp
{
    public partial class FilterRecipesWindow : Window
    {
        private RecipeManager _recipeManager;

        public FilterRecipesWindow(RecipeManager recipeManager)
        {
            InitializeComponent();
            _recipeManager = recipeManager;
        }

        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            string ingredient = IngredientFilterTextBox.Text;
            var filteredRecipes = _recipeManager.GetRecipes()
                .Where(r => r.Ingredients.Any(i => i.Name.Equals(ingredient, System.StringComparison.OrdinalIgnoreCase)))
                .ToList();

            var foodGroups = filteredRecipes.SelectMany(r => r.Ingredients).GroupBy(i => i.FoodGroup);
            SeriesCollection series = new SeriesCollection();

            foreach (var group in foodGroups)
            {
                series.Add(new PieSeries
                {
                    Title = group.Key,
                    Values = new ChartValues<int> { group.Count() }
                });
            }

            PieChart.Series = series;
        }
    }
}
