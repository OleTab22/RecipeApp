namespace RecipeApp2
{
    /// <summary>
    /// Represents a single step in a recipe. This class holds the description of what needs to be done at this step.
    /// </summary>
    internal class Step
    {
        // Property to store the description of the step.
        public string Description { get; }

        /// <summary>
        /// Constructor to create a new step with a description.
        /// </summary>
        /// <param name="description">The text describing what this step involves.</param>
        public Step(string description)
        {
            Description = description; // Initialize the description with the provided text.
        }

        /// <summary>
        /// Provides a string representation of the step, useful for displaying in lists or outputs.
        /// </summary>
        /// <returns>A string that represents the step's description.</returns>
        public override string ToString()
        {
            return Description; // Return the description of the step.

        }
    }
}
