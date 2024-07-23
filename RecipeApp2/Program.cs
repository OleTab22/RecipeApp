using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp2
{
    class Program
    {
        // Create an instance of RecipeManager to manage the recipes
        private static RecipeManager _recipeManager = new RecipeManager();

        // Entry point of the application
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to RecipeApp!");
            DisplayMainMenu();
        }

        // Display the main menu and handle user input
        private static void DisplayMainMenu()
        {
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Create a new recipe");
                Console.WriteLine("2. View all recipes");
                Console.WriteLine("3. Search for a recipe by name");
                Console.WriteLine("4. Exit");

                // Read the user's choice and ensure it's between 1 and 4
                int choice = ReadInteger("Enter your choice (1-4): ", 1, 4).Value;

                // Handle the user's choice
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
                        // Confirm if the user really wants to exit
                        if (ConfirmAction("Are you sure you want to exit?"))
                        {
                            Console.WriteLine("Exiting RecipeApp. Goodbye!");
                            return;
                        }
                        break;
                }
            }
        }

        // Display all recipes stored in the RecipeManager
        private static void DisplayAllRecipes()
        {
            var recipes = _recipeManager.GetRecipes();
            foreach (var recipe in recipes)
            {
                DisplayRecipe(recipe);
            }
        }

        // Display the details of a single recipe
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
            // Alert if the total calories exceed 300
            if (recipe.TotalCalories > 300)
            {
                HandleCalorieExceeded(recipe.TotalCalories);
            }
        }

        // Create a new recipe by gathering input from the user
        private static void CreateNewRecipe()
        {
            Console.WriteLine("\nEnter the name of the recipe:");
            string name = Console.ReadLine();
            int numberOfIngredients = ReadInteger("Enter the number of ingredients: ", 1, 100).Value;

            var ingredients = new List<Ingredient>();
            for (int i = 0; i < numberOfIngredients; i++)
            {
                Console.WriteLine($"\nEnter details for ingredient {i + 1}:");
                string ingredientName = ReadString("Name: ");
                double quantity = ReadDouble("Quantity: ");
                string unit = ReadString("Unit of measurement: ");
                int calories = ReadInteger("Calories: ", 0, 10000).Value;
                string foodGroup = ReadString("Food Group: ");
                ingredients.Add(new Ingredient(ingredientName, quantity, unit, calories, foodGroup));
            }

            int numberOfSteps = ReadInteger("Enter the number of steps: ", 1, 100).Value;
            var steps = new List<string>();
            for (int i = 0; i < numberOfSteps; i++)
            {
                steps.Add(ReadString($"Step {i + 1}: "));
            }

            var recipe = new Recipe(name, ingredients, steps);
            _recipeManager.AddRecipe(recipe);
            Console.WriteLine("Recipe added successfully!");
        }

        // Search for recipes by name and display the results
        private static void SearchRecipesByName()
        {
            Console.WriteLine("\nEnter the name of the recipe to search for:");
            string name = Console.ReadLine();
            var recipes = _recipeManager.SearchRecipesByName(name);
            if (recipes.Any())
            {
                foreach (var recipe in recipes)
                {
                    DisplayRecipe(recipe);
                }
            }
            else
            {
                Console.WriteLine("No recipes found with that name.");
            }
        }

        // Read an integer from the user within a specified range
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

        // Read a string from the user
        private static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        // Read a double from the user
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

        // Confirm an action with the user
        private static bool ConfirmAction(string message)
        {
            Console.Write($"{message} (y/n): ");
            return Console.ReadLine().Trim().ToLower() == "y";
        }

        // Handle the case when total calories exceed a certain limit
        private static void HandleCalorieExceeded(int totalCalories)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Alert: Total calories exceed 300! Current calories: {totalCalories}");
            Console.ResetColor();
        }
    }
}
