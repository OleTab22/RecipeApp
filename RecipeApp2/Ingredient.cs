using System;
using System.Collections.Generic;

namespace RecipeApp2
{
    /// <summary>
    /// Represents an ingredient used in a recipe. This class holds details like name, quantity, and calories.
    /// </summary>
    internal class Ingredient
    {
        // Nested enum for food groups
        public enum FoodGroup
        {
            StarchyFoods,      // Includes bread, pasta, rice, and other grains.
            VegetablesAndFruits, // Includes all types of fruits and vegetables.
            Legumes,           // Includes beans, lentils, and peas.
            ProteinSources,    // Includes meat, poultry, fish, and eggs.
            Dairy,             // Includes milk, cheese, and yogurt.
            FatsAndOils,       // Includes butter, oils, and fatty fruits like avocados.
            Water              // Essential for hydration, includes water and water-rich foods.
        }

        // Properties to store the essential details of an ingredient.
        public string Name { get; private set; } // The name of the ingredient.
        public double Quantity { get; set; } // The amount of the ingredient used.
        public double OriginalQuantity { get; private set; } // The original amount before any modifications.
        public string Unit { get; private set; } // The measurement unit (e.g., cups, tablespoons).
        public int Calories { get; set; } // Calories per unit of the ingredient.
        public FoodGroup Group { get; set; } // The food group this ingredient belongs to.

        /// <summary>
        /// Constructor to create a new ingredient with all necessary details.
        /// </summary>
        /// <param name="name">Name of the ingredient.</param>
        /// <param name="quantity">Quantity of the ingredient.</param>
        /// <param name="unit">Unit of measurement for the quantity.</param>
        /// <param name="calories">Calories per unit.</param>
        /// <param name="group">Food group of the ingredient.</param>
        public Ingredient(string name, double quantity, string unit, int calories, FoodGroup group)
        {
            Name = name;
            OriginalQuantity = quantity;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            Group = group;
        }

        /// <summary>
        /// Provides a string representation of the ingredient, useful for displaying in lists.
        /// </summary>
        /// <returns>A string that represents the ingredient.</returns>
        public override string ToString()
        {
            return $"{Quantity} {Unit} of {Name}"; // E.g., "2 cups of flour"
        }

        /// <summary>
        /// Scales the quantity of the ingredient by a specified factor.
        /// </summary>
        /// <param name="factor">The factor by which to scale the quantity.</param>
        public void ScaleQuantity(double factor)
        {
            Quantity *= factor; // Multiply the current quantity by the factor.
        }

        /// <summary>
        /// Resets the quantity of the ingredient to its original value.
        /// </summary>
        public void ResetQuantity()
        {
            Quantity = OriginalQuantity; // Reset to the original quantity.
        }

        /// <summary>
        /// Retrieves the default unit of measurement for common ingredients.
        /// </summary>
        /// <param name="ingredientName">The name of the ingredient.</param>
        /// <returns>The default unit as a string.</returns>
        public static string GetDefaultUnit(string ingredientName)
        {
            switch (ingredientName.ToLower())
            {
                case "flour":
                case "sugar":
                    return "cups";
                case "butter":
                    return "tablespoons";
                case "eggs":
                    return "pieces";
                default:
                    return "units"; // Default unit if not specified.
            }
        }

        /// <summary>
        /// Allows the user to specify a unit for the ingredient or choose the default.
        /// </summary>
        /// <param name="ingredientName">The name of the ingredient to get the unit for.</param>
        /// <returns>The chosen unit.</returns>
        public static string GetUnitFromUser(string ingredientName)
        {
            while (true)
            {
                Console.Write($"Enter unit for {ingredientName} (or press Enter for default, type 'exit' to cancel): ");
                string unit = Console.ReadLine()?.Trim().ToLower() ?? "";
                if (unit == "exit")
                {
                    Console.WriteLine("Operation cancelled.");
                    return null; // Return null to indicate cancellation
                }
                if (string.IsNullOrWhiteSpace(unit))
                {
                    unit = GetDefaultUnit(ingredientName);
                    Console.WriteLine($"Default unit ({unit}) selected.");
                    return unit;
                }
                else if (IsValidUnit(unit))
                {
                    return unit;
                }
                else
                {
                    Console.WriteLine("Invalid unit. Please enter a valid unit, leave blank for default, or type 'exit' to cancel.");
                }
            }
        }

        /// <summary>
        /// Validates if a given unit is recognized and valid.
        /// </summary>
        /// <param name="unit">The unit to validate.</param>
        /// <returns>True if the unit is valid, otherwise false.</returns>
        private static bool IsValidUnit(string unit)
        {
            var validUnits = new HashSet<string> { "cups", "tablespoons", "pieces", "units" };
            return validUnits.Contains(unit);
        }

        /// <summary>
        /// Helps the user choose a food group for the ingredient by displaying options and reading their choice.
        /// It's a way to categorize ingredients based on their nutritional properties.
        /// </summary>
        /// <returns>The selected FoodGroup.</returns>
        public static FoodGroup? ChooseFoodGroup()
        {
            Console.WriteLine("Select a food group for the ingredient. Each group is based on common nutritional properties:");
            int index = 1;
            foreach (var group in Enum.GetValues(typeof(FoodGroup)))
            {
                string description = GetFoodGroupDescription((FoodGroup)group);
                Console.WriteLine($"{index}. {group} - {description}");
                index++;
            }
            while (true)
            {
                Console.Write("Enter your choice (number, or type 'exit' to cancel): ");
                string input = Console.ReadLine()?.Trim().ToLower();
                if (input == "exit")
                {
                    Console.WriteLine("Operation cancelled.");
                    return null; // Return null to indicate cancellation
                }
                if (int.TryParse(input, out int groupIndex) && groupIndex >= 1 && groupIndex <= Enum.GetValues(typeof(FoodGroup)).Length)
                {
                    return (FoodGroup)(groupIndex - 1);
                }
                else
                {
                    Console.WriteLine($"Invalid choice. Please enter a number between 1 and {Enum.GetValues(typeof(FoodGroup)).Length} or type 'exit' to cancel.");
                }
            }
        }

        /// <summary>
        /// Provides a description for each food group, making it easier to understand their significance.
        /// </summary>
        /// <param name="group">The food group to describe.</param>
        /// <returns>A string description of the food group.</returns>
        private static string GetFoodGroupDescription(FoodGroup group)
        {
            switch (group)
            {
                case FoodGroup.StarchyFoods:
                    return "Includes bread, pasta, rice, and other grains.";
                case FoodGroup.VegetablesAndFruits:
                    return "Includes all types of fruits and vegetables.";
                case FoodGroup.Legumes:
                    return "Includes beans, lentils, and peas.";
                case FoodGroup.ProteinSources:
                    return "Includes meat, poultry, fish, and eggs.";
                case FoodGroup.Dairy:
                    return "Includes milk, cheese, and yogurt.";
                case FoodGroup.FatsAndOils:
                    return "Includes butter, oils, and fatty fruits like avocados.";
                case FoodGroup.Water:
                    return "Essential for hydration, includes water and water-rich foods.";
                default:
                    return "No description available.";
            }
        }

        /// <summary>
        /// Reads an integer from the console after prompting the user, ensuring it falls within a specified range.
        /// </summary>
        /// <param name="prompt">The prompt to display to the user.</param>
        /// <param name="min">The minimum acceptable value.</param>
        /// <param name="max">The maximum acceptable value.</param>
        /// <returns>The integer value entered by the user.</returns>
        private static int ReadInteger(string prompt, int min, int max)
        {
            int value;
            do
            {
                Console.Write(prompt);
                if (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max)
                {
                    Console.WriteLine($"Please enter a valid number between {min} and {max}.");
                }
                else
                {
                    break;
                }
            } while (true);
            return value;
        }
    }
}
