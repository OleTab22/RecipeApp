namespace RecipeApp2
{
    /// <summary>
<<<<<<< HEAD
    /// This class represents a single step in a recipe. It holds the description of what needs to be done at this step.
    /// </summary>
    internal class Step
    {
        /// <summary>
        /// Gets the description of the step.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Creates a new step with the given description.
=======
    /// Represents a single step in a recipe. This class holds the description of what needs to be done at this step.
    /// </summary>
    internal class Step
    {
        // Property to store the description of the step.
        public string Description { get; }

        /// <summary>
        /// Constructor to create a new step with a description.
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
        /// </summary>
        /// <param name="description">The text describing what this step involves.</param>
        public Step(string description)
        {
<<<<<<< HEAD
            // Make sure the description is not empty or just whitespace.
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be empty", nameof(description));

            Description = description;
        }

        /// <summary>
        /// Returns the description of the step as a string, which is useful for displaying in lists or outputs.
=======
            Description = description; // Initialize the description with the provided text.
        }

        /// <summary>
        /// Provides a string representation of the step, useful for displaying in lists or outputs.
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
        /// </summary>
        /// <returns>A string that represents the step's description.</returns>
        public override string ToString()
        {
<<<<<<< HEAD
            return Description;
        }
    }
}
=======
            return Description; // Return the description of the step.

        }
    }
}
>>>>>>> e3a71bc745c15ccebc7f1f8c64cd8558e104d742
