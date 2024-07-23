using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp2
{
    class Program
    {
        private static RecipeManager _recipeManager = new RecipeManager();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to RecipeApp!");
            DisplayMainMenu();
        }

        // Displays the main menu and handles user input.
        private static void DisplayMainMenu()
        {
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Create a new recipe");
                Console.WriteLine("2. View all recipes");
                Console.WriteLine("3. Search for a recipe by name");
                Console.WriteLine("4. Exit");

                int choice = ReadInteger("Enter your choice (1-4): ", 1, 4).Value;

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
                            return;
                        }
                        break;
                }
            }
        }

        // Displays all recipes.
        private static void DisplayAllRecipes()
        {
            var recipes = _recipeManager.GetRecipes();
            foreach (var recipe in recipes)
            {
                DisplayRecipe(recipe);
            }
        }

        // Displays a single recipe.
        private static void DisplayRecipe(Recipe recipe)
        {
            Console.WriteLine($"\nRecipe: {recipe.Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            }
            Console.WriteLine("Steps:");
            foreach (var step in recipe.Steps)
            {
                Console.WriteLine($"- {step}");
            }
            Console.WriteLine($"Total Calories: {recipe.TotalCalories}");
            if (recipe.TotalCalories > 300)
            {
                HandleCalorieExceeded(recipe.TotalCalories);
            }
        }

        // Creates a new recipe by collecting user input.
        private static void CreateNewRecipe()
        {
            try
            {
                Console.WriteLine("Enter recipe name:");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Recipe name cannot be empty.");
                    return;
                }

                var ingredients = new List<Ingredient>();
                var steps = new List<string>();

                // Collect ingredients
                while (true)
                {
                    Console.WriteLine("Enter ingredient name (or type 'done' to finish):");
                    string ingredientName = Console.ReadLine();
                    if (ingredientName.Trim().ToLower() == "done") break;

                    double quantity = ReadDouble("Enter ingredient quantity:");
                    Console.WriteLine("Enter ingredient unit:");
                    string unit = Console.ReadLine();
                    int calories = ReadInteger("Enter ingredient calories:", 0, int.MaxValue).Value;

                    ingredients.Add(new Ingredient(ingredientName, quantity, unit, calories, "Unknown"));
                }

                // Collect steps
                while (true)
                {
                    Console.WriteLine("Enter step description (or type 'done' to finish):");
                    string step = Console.ReadLine();
                    if (step.Trim().ToLower() == "done") break;

                    steps.Add(step);
                }

                var recipe = new Recipe(name, ingredients, steps);
                _recipeManager.AddRecipe(recipe);

                Console.WriteLine("Recipe added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Searches for recipes by name.
        private static void SearchRecipesByName()
        {
            Console.WriteLine("Enter recipe name to search for:");
            string name = Console.ReadLine();
            var recipe = _recipeManager.GetRecipeByName(name);
            if (recipe != null)
            {
                DisplayRecipe(recipe);
            }
            else
            {
                Console.WriteLine("No recipe found with that name.");
            }
        }

        // Reads an integer from the user with validation.
        private static int? ReadInteger(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt + " (or type 'cancel' to cancel): ");
                string input = Console.ReadLine();
                if (input.Trim().ToLower() == "cancel")
                {
                    Console.WriteLine("Input cancelled.");
                    return null;
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

        // Reads a string from the user.
        private static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        // Reads a double from the user with validation.
        private static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }

        // Confirms an action with the user.
        private static bool ConfirmAction(string message)
        {
            Console.Write($"{message} (y/n): ");
            return Console.ReadLine().Trim().ToLower() == "y";
        }

        // Handles the case when total calories exceed a certain limit.
        private static void HandleCalorieExceeded(int totalCalories)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Alert: Total calories exceed 300! Current calories: {totalCalories}");
            Console.ResetColor();
        }
    }
}