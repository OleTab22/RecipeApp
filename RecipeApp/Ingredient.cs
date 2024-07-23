namespace RecipeApp
{
<<<<<<< HEAD
    /// <summary>
    /// Represents an ingredient used in a recipe.
    /// </summary>
    public class Ingredient
    {
        /// <summary>
        /// Gets or sets the name of the ingredient.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the ingredient.
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit of measurement for the quantity.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the number of calories in the specified quantity of the ingredient.
        /// </summary>
        public int Calories { get; set; }

        /// <summary>
        /// Gets or sets the food group to which the ingredient belongs.
        /// </summary>
        public string FoodGroup { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ingredient"/> class.
        /// </summary>
        /// <param name="name">The name of the ingredient.</param>
        /// <param name="quantity">The quantity of the ingredient.</param>
        /// <param name="unit">The unit of measurement for the quantity.</param>
        /// <param name="calories">The number of calories in the specified quantity.</param>
        /// <param name="foodGroup">The food group to which the ingredient belongs.</param>
        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            // Validate that the name is not empty or whitespace.
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));

            // Validate that the quantity is positive.
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive", nameof(quantity));

            // Validate that the calories are not negative.
            if (calories < 0)
                throw new ArgumentException("Calories cannot be negative", nameof(calories));

=======
    // The Ingredient class represents a single ingredient used in a recipe.
    // It contains properties for the ingredient's name, quantity, unit of measurement, calories, and food group.
    public class Ingredient
    {
        // The name of the ingredient (e.g., "Sugar").
        public string Name { get; set; }

        // The quantity of the ingredient (e.g., 2.5).
        public double Quantity { get; set; }

        // The unit of measurement for the quantity (e.g., "cups").
        public string Unit { get; set; }

        // The number of calories in the specified quantity of the ingredient.
        public int Calories { get; set; }

        // The food group to which the ingredient belongs (e.g., "Dairy", "Vegetables").
        public string FoodGroup { get; set; }

        // Constructor to initialize an Ingredient object with the provided values.
        // Parameters:
        //   name - The name of the ingredient.
        //   quantity - The quantity of the ingredient.
        //   unit - The unit of measurement for the quantity.
        //   calories - The number of calories in the specified quantity.
        //   foodGroup - The food group to which the ingredient belongs.
        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
