namespace RecipeApp2
{
    // The Ingredient class represents an ingredient used in a recipe.
    // It includes properties for the name, quantity, unit of measurement, calories, and food group of the ingredient.
    public class Ingredient
    {
        // The name of the ingredient (e.g., "Sugar").
        public string Name { get; set; }

        // The quantity of the ingredient required (e.g., 2.5).
        public double Quantity { get; set; }

        // The unit of measurement for the quantity (e.g., "cups").
        public string Unit { get; set; }

        // The number of calories in the specified quantity of the ingredient.
        public int Calories { get; set; }

        // The food group to which the ingredient belongs (e.g., "Dairy", "Vegetables").
        public string FoodGroup { get; set; }

        // Constructor to initialize an Ingredient object with the provided name, quantity, unit, calories, and food group.
        // Parameters:
        //   name - The name of the ingredient.
        //   quantity - The quantity of the ingredient required.
        //   unit - The unit of measurement for the quantity.
        //   calories - The number of calories in the specified quantity of the ingredient.
        //   foodGroup - The food group to which the ingredient belongs.
        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }
}
