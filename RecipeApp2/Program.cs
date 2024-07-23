using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp2
{
    class Program
    {
<<<<<<< HEAD
        private static RecipeManager _recipeManager = new RecipeManager();

=======
        // Create an instance of RecipeManager to manage the recipes
        private static RecipeManager _recipeManager = new RecipeManager();

        // Entry point of the application
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to RecipeApp!");
            DisplayMainMenu();
        }

<<<<<<< HEAD
        // Displays the main menu and handles user input.
=======
        // Display the main menu and handle user input
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
        private static void DisplayMainMenu()
        {
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Create a new recipe");
                Console.WriteLine("2. View all recipes");
                Console.WriteLine("3. Search for a recipe by name");
                Console.WriteLine("4. Exit");

<<<<<<< HEAD
                int choice = ReadInteger("Enter your choice (1-4): ", 1, 4).Value;

=======
                // Read the user's choice and ensure it's between 1 and 4
                int choice = ReadInteger("Enter your choice (1-4): ", 1, 4).Value;

                // Handle the user's choice
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
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
<<<<<<< HEAD
=======
                        // Confirm if the user really wants to exit
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
                        if (ConfirmAction("Are you sure you want to exit?"))
                        {
                            Console.WriteLine("Exiting RecipeApp. Goodbye!");
                            return;
                        }
                        break;
                }
            }
        }

<<<<<<< HEAD
        // Displays all recipes.
=======
        // Display all recipes stored in the RecipeManager
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
        private static void DisplayAllRecipes()
        {
            var recipes = _recipeManager.GetRecipes();
            foreach (var recipe in recipes)
            {
                DisplayRecipe(recipe);
            }
        }

<<<<<<< HEAD
        // Displays a single recipe.
=======
        // Display the details of a single recipe
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
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
<<<<<<< HEAD
=======
            // Alert if the total calories exceed 300
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
            if (recipe.TotalCalories > 300)
            {
                HandleCalorieExceeded(recipe.TotalCalories);
            }
        }

<<<<<<< HEAD
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
=======
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
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
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

<<<<<<< HEAD
        // Reads a string from the user.
=======
        // Read a string from the user
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
        private static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

<<<<<<< HEAD
        // Reads a double from the user with validation.
=======
        // Read a double from the user
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
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

<<<<<<< HEAD
        // Confirms an action with the user.
=======
        // Confirm an action with the user
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
        private static bool ConfirmAction(string message)
        {
            Console.Write($"{message} (y/n): ");
            return Console.ReadLine().Trim().ToLower() == "y";
        }

<<<<<<< HEAD
        // Handles the case when total calories exceed a certain limit.
=======
        // Handle the case when total calories exceed a certain limit
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
        private static void HandleCalorieExceeded(int totalCalories)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Alert: Total calories exceed 300! Current calories: {totalCalories}");
            Console.ResetColor();
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
