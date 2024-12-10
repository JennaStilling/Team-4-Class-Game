namespace Composite
{
    public interface IQuest
    {
        // Method to mark the quest as completed
        void CompleteQuest();

        // Method to check if the quest is complete
        bool IsComplete();

        // Methods for setting and getting quest descriptions and names
        void SetDescription(string description);
        string GetDescription();

        void SetName(string name);
        string GetName();

        // Optional: Method to get the potion ID associated with the quest (for subquests)
        int GetPotionId();

        // Method for converting quest info to a string
        string ToString();
    }
}