using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp2
{
    class Program
    {
        // A list to store all the recipes created in the app.
        static List<Recipe> recipes = new List<Recipe>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to RecipeApp!");
            DisplayMainMenu();
        }

        /// <summary>
        /// Displays the main menu and handles user interaction.
        /// </summary>
        static void DisplayMainMenu()
        {
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Create a new recipe");
                Console.WriteLine("2. View all recipes");
                Console.WriteLine("3. Search for a recipe by name");
                Console.WriteLine("4. Exit");

                int choice = ReadInteger("Enter your choice (1-4): ", 1, 4);

                switch (choice)
                {
                    case 1:
                        CreateNewRecipe();
                        break;
                    case 2:
                        DisplayAllRecipes();
                        break;
                    case 3:
                        SearchRecipesByName();
                        break;
                    case 4:
                        if (ConfirmAction("Are you sure you want to exit?"))
                        {
                            Console.WriteLine("Exiting RecipeApp. Goodbye!");
                            return; // Exit the program
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Displays all recipes in alphabetical order.
        /// </summary>
        static void DisplayAllRecipes()
        {
            var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
            foreach (var recipe in sortedRecipes)
            {
                recipe.DisplayRecipe();
            }
        }

        /// <summary>
        /// Guides the user through creating a new recipe.
        /// </summary>
        static void CreateNewRecipe()
        {
            Console.Write("Enter the name of the recipe: ");
            string recipeName = Console.ReadLine() ?? "";
            Recipe currentRecipe = new Recipe(recipeName);
            currentRecipe.OnCalorieExceeded += HandleCalorieExceeded;  // Subscribe to the event
            recipes.Add(currentRecipe);
            Console.WriteLine($"Recipe '{recipeName}' created.");

            try
            {
                while (true)
                {
                    // Display recipe editing options
                    Console.WriteLine("\nChoose an option:");
                    Console.WriteLine("1. Enter ingredients");
                    Console.WriteLine("2. Enter steps");
                    Console.WriteLine("3. Display recipe");
                    Console.WriteLine("4. Scale recipe");
                    Console.WriteLine("5. Reset quantities");
                    Console.WriteLine("6. Clear recipe");
                    Console.WriteLine("7. Exit to main menu");

                    // Prompt user for choice
                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine()!; // Input choice from user

                    switch (choice)
                    {
                        case "1":
                            EnterIngredients(currentRecipe); // Add ingredients to the recipe
                            break;
                        case "2":
                            EnterSteps(currentRecipe); // Add steps to the recipe
                            break;
                        case "3":
                            currentRecipe.DisplayRecipe(); // Display the recipe
                            break;
                        case "4":
                            ScaleRecipe(currentRecipe); // Scale the recipe
                            break;
                        case "5":
                            currentRecipe.ResetQuantities(); // Reset ingredient quantities
                            break;
                        case "6":
                            if (ConfirmAction("Are you sure you want to clear the recipe?"))
                            {
                                currentRecipe.ClearRecipe();
                                Console.WriteLine("Recipe cleared.");
                            }
                            break;
                        case "7":
                            Console.WriteLine("Returning to main menu.");
                            return; // Return to main menu
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number from 1 to 7.");
                            break;
                    }
                }
            }
            finally
            {
                // Unsubscribe from the event when exiting the recipe editing mode
                currentRecipe.OnCalorieExceeded -= HandleCalorieExceeded;
                Console.WriteLine("Unsubscribed from calorie exceeded event.");
            }
        }

        /// <summary>
        /// Allows the user to enter ingredients for a recipe.
        /// </summary>
        /// <param name="recipe">The recipe to add ingredients to.</param>
        static void EnterIngredients(Recipe recipe)
        {
            int numIngredients = ReadInteger("Enter the number of ingredients (1-100): ", 1, 100);
            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Enter name for ingredient {i + 1}: ");
                string name = Console.ReadLine() ?? "";

                Console.Write($"Enter quantity for {name} (e.g., 2.5): ");
                string quantityInput = Console.ReadLine() ?? "";
                if (double.TryParse(quantityInput, out double quantity))
                {
                    string unit = Ingredient.GetUnitFromUser(name);
                    Console.Write($"Enter calories per unit for {name} (e.g., 100): ");
                    string caloriesInput = Console.ReadLine() ?? "";
                    if (int.TryParse(caloriesInput, out int calories))
                    {
                        Ingredient.FoodGroup group = Ingredient.ChooseFoodGroup();
                        recipe.Ingredients.Add(new Ingredient(name, quantity, unit, calories, group));
                        Console.WriteLine("Ingredient added successfully.\n");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for calories. Please enter a valid number.");
                        i--; // Re-enter this ingredient
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input for quantity. Please enter a valid number.");
                    i--; // Re-enter this ingredient
                }
            }
        }

        /// <summary>
        /// Allows the user to enter steps for a recipe.
        /// </summary>
        /// <param name="recipe">The recipe to add steps to.</param>
        static void EnterSteps(Recipe recipe)
        {
            int numSteps = ReadInteger("Enter the number of steps: ", 1, 100);
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1} description: ");
                string description = Console.ReadLine() ?? "";
                recipe.Steps.Add(new Step(description));
                Console.WriteLine("Step added successfully.");
            }
        }

        /// <summary>
        /// Scales the recipe by a user-specified factor.
        /// </summary>
        /// <param name="recipe">The recipe to scale.</param>
        static void ScaleRecipe(Recipe recipe)
        {
            Console.Write("Enter scale factor (0.5, 2, or 3): ");
            string input = Console.ReadLine() ?? "";

            if (double.TryParse(input, out double factor))
            {
                recipe.ScaleRecipe(factor);
                Console.WriteLine($"Recipe scaled by a factor of {factor}.");
                Console.WriteLine($"New Total Calories after scaling: {recipe.CalculateTotalCalories()}");
            }
            else
            {
                Console.WriteLine("Invalid scale factor. Please enter a valid number.");
            }
        }

        /// <summary>
        /// Confirms an action with the user before proceeding.
        /// </summary>
        /// <param name="message">The confirmation message to display.</param>
        /// <returns>True if the user confirms, false otherwise.</returns>
        static bool ConfirmAction(string message)
        {
            Console.Write(message + " (Y/N): ");
            string response = Console.ReadLine().Trim().ToUpper();
            return response == "Y";
        }

        /// <summary>
        /// Searches for recipes by name.
        /// </summary>
        /// <param name="searchName">The name to search for.</param>
        static void SearchRecipesByName()
        {
            Console.Write("Enter the recipe name to search for (or type 'cancel' to cancel): ");
            string searchName = Console.ReadLine().Trim().ToLower();
            if (searchName == "cancel")
            {
                Console.WriteLine("Search cancelled.");
                return;
            }
            var foundRecipes = recipes.Where(r => r.Name.ToLower().Contains(searchName)).ToList();

            if (foundRecipes.Any())
            {
                foreach (var recipe in foundRecipes)
                {
                    recipe.DisplayRecipe();
                }
            }
            else
            {
                Console.WriteLine("No recipes found with that name.");
            }
        }

        /// <summary>
        /// Reads an integer from the console after prompting the user, ensuring it falls within a specified range.
        /// Allows the user to cancel the input by entering 'cancel'.
        /// </summary>
        /// <param name="prompt">The prompt to display to the user.</param>
        /// <param name="min">The minimum acceptable value.</param>
        /// <param name="max">The maximum acceptable value.</param>
        /// <returns>The integer value entered by the user or null if cancelled.</returns>
        static int? ReadInteger(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt + " (or type 'cancel' to cancel): ");
                string input = Console.ReadLine();
                if (input.Trim().ToLower() == "cancel")
                {
                    Console.WriteLine("Input cancelled.");
                    return null; // Return null to indicate cancellation
                }
                if (int.TryParse(input, out int value) && value >= min && value <= max)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Please enter a valid number between {min} and {max} or type 'cancel'.");
                }
            }
        }

        /// <summary>
        /// Handles the event when the total calories of a recipe exceed a certain threshold.
        /// </summary>
        /// <param name="totalCalories">The total calories that triggered the alert.</param>
        static void HandleCalorieExceeded(int totalCalories)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Alert: Total calories exceed 300! Current calories: {totalCalories}");
            Console.ResetColor();
        }
    }
}
}
}