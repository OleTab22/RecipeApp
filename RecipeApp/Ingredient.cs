namespace RecipeApp
{
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

            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }
}