namespace RecipeApp2
{
    /// <summary>
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
        /// </summary>
        /// <param name="description">The text describing what this step involves.</param>
        public Step(string description)
        {
            // Make sure the description is not empty or just whitespace.
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be empty", nameof(description));

            Description = description;
        }

        /// <summary>
        /// Returns the description of the step as a string, which is useful for displaying in lists or outputs.
        /// </summary>
        /// <returns>A string that represents the step's description.</returns>
        public override string ToString()
        {
            return Description;
        }
    }
}