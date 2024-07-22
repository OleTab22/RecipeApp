namespace RecipeApp2
{
    /// <summary>
    /// Delegate for handling events when the calorie count exceeds a certain threshold.
    /// </summary>
    /// <param name="totalCalories">The total calories that triggered the alert.</param>
    public delegate void CalorieExceededHandler(int totalCalories);

    /// <summary>
    /// Represents a cooking recipe, which includes a list of ingredients and preparation steps.
    /// </summary>
    internal class Recipe
    {
        // Properties
        public string Name { get; set; } // Name of the recipe.
        public List<Ingredient> Ingredients { get; } = new List<Ingredient>(); // List of ingredients used in the recipe.
        public List<Step> Steps { get; } = new List<Step>(); // List of preparation steps for the recipe.

        /// <summary>
        /// Event triggered when the total calories of the recipe exceed a certain threshold.
        /// </summary>
        public event CalorieExceededHandler? OnCalorieExceeded;

        /// <summary>
        /// Initializes a new instance of the Recipe class with a specified name.
        /// </summary>
        /// <param name="name">The name of the recipe.</param>
        public Recipe(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Displays the recipe details including ingredients, steps, and total calories.
        /// </summary>
        public void DisplayRecipe()
        {
            // Recipe Name in Magenta
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\nRecipe: {Name}\n");
            Console.ResetColor();

            // Ingredients in Green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"- {ingredient.ToString()}");
            }
            Console.ResetColor();

            // Steps in Cyan
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nSteps:");
            foreach (var step in Steps)
            {
                Console.WriteLine($"- {step.ToString()}");
            }
            Console.ResetColor();

            // Total Calories in Yellow
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nTotal Calories: {CalculateTotalCalories()}\n");
            Console.ResetColor();

            CheckCalorieThreshold();
        }

        /// <summary>
        /// Scales the quantities of ingredients in the recipe by a specified factor and recalculates the total calories.
        /// </summary>
        /// <param name="factor">The factor by which to scale the ingredient quantities.</param>
        public void ScaleRecipe(double factor)
        {
            // Inform the user about what scaling will do
            Console.WriteLine("Scaling will adjust ingredient quantities but keep calories per unit constant.");
            
            // Ask for user confirmation to proceed with scaling
            Console.WriteLine("Do you want to proceed with scaling the recipe? (Y/N)");
            string confirmation = Console.ReadLine();
            if (confirmation?.ToUpper() != "Y")
            {
                Console.WriteLine("Scaling cancelled by user.");
                return;
            }

            // Display original total calories for reference
            int originalTotalCalories = CalculateTotalCalories();
            Console.WriteLine($"Original Total Calories: {originalTotalCalories}");

            // Scale each ingredient and provide detailed feedback
            Console.WriteLine("Scaling ingredients...");
            foreach (var ingredient in Ingredients)
            {
                double originalQuantity = ingredient.Quantity;
                ingredient.ScaleQuantity(factor);
                Console.WriteLine($"{ingredient.Name}: {originalQuantity} {ingredient.Unit} -> {ingredient.Quantity} {ingredient.Unit}");
            }

            // Recalculate and display new total calories
            int newTotalCalories = CalculateTotalCalories();
            Console.WriteLine($"New Total Calories after scaling: {newTotalCalories}");

            // Check if the new total calories exceed the threshold and handle accordingly
            CheckCalorieThreshold();

            // Provide a summary of the scaling operation
            Console.WriteLine("Scaling completed successfully.");
        }

        /// <summary>
        /// Provides the user with options to either reset the quantities of all ingredients to their original values or to manually enter new values for each ingredient.
        /// </summary>
        public void ResetQuantities()
        {
            // Prompt the user to choose between resetting to original values or entering new values
            Console.WriteLine("Do you want to reset to original values (1) or enter new values (2)?");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine()!; // Read user input

            // Handle the user's choice
            switch (choice)
            {
                case "1":
                    // Reset all ingredient quantities to their original values
                    ResetToOriginalValues();
                    Console.WriteLine("Quantities reset to original values.");
                    break;
                case "2":
                    // Allow the user to enter new quantities for each ingredient
                    EnterNewValues();
                    Console.WriteLine("New quantities entered.");
                    break;
                default:
                    // Handle invalid input by prompting the user to enter a valid choice
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                    break;
            }
        }

        /// <summary>
        /// Calculates the total calories of the recipe based on ingredients and their quantities.
        /// </summary>
        /// <returns>The total calorie count of the recipe.</returns>
        public int CalculateTotalCalories()
        {
            int totalCalories = Ingredients.Sum(ingredient => ingredient.Calories * (int)ingredient.Quantity);
            if (totalCalories > 300)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Alert: Total calories exceed 300! Current calories: {totalCalories}");
                Console.ResetColor();
            }
            return totalCalories;
        }

        /// <summary>
        /// Checks if the total calories of the recipe exceed a predefined threshold and triggers an event if they do.
        /// </summary>
        private void CheckCalorieThreshold()
        {
            int totalCalories = CalculateTotalCalories(); // Calculate the current total calories of the recipe
            if (totalCalories > 300) // Check if the total calories exceed the threshold of 300
            {
                // Safe invocation of the event
                OnCalorieExceeded?.Invoke(totalCalories);
            }
        }

        /// <summary>
        /// Resets all ingredient quantities to their original values.
        /// </summary>
        private void ResetToOriginalValues()
        {
            foreach (var ingredient in Ingredients) // Iterate through each ingredient in the recipe
            {
                ingredient.ResetQuantity(); // Call the ResetQuantity method on each ingredient
            }
        }

        /// <summary>
        /// Allows the user to manually enter new quantities for each ingredient.
        /// </summary>
        private void EnterNewValues()
        {
            foreach (var ingredient in Ingredients) // Iterate through each ingredient in the recipe
            {
                double quantity;
                while (true) // Continue to prompt until a valid input is received or the user decides to skip
                {
                    Console.Write($"Enter new quantity for {ingredient.Name} (or type 'skip' to skip): ");
                    string input = Console.ReadLine()!;
                    if (input.Trim().ToLower() == "skip")
                    {
                        Console.WriteLine($"Skipping {ingredient.Name}.");
                        break; // Skip this ingredient
                    }
                    if (double.TryParse(input, out quantity)) // Try to parse the input as a double
                    {
                        ingredient.Quantity = quantity; // Set the new quantity if parsing is successful
                        Console.WriteLine($"{ingredient.Name} updated to {quantity} {ingredient.Unit}.");
                        break; // Exit the loop after successful input
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity. Please enter a valid number or type 'skip'."); // Inform the user of invalid input
                    }
                }
            }
        }

        /// <summary>
        /// Clears all ingredients and steps from the recipe.
        /// </summary>
        public void ClearRecipe()
        {
            Ingredients.Clear(); // Clear all ingredients
            Steps.Clear(); // Clear all steps
        }
    }
}

