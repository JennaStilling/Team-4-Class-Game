namespace Composite
{
    public interface IQuest
    {
        void CompleteQuest();
        bool IsComplete();
        void SetDescription(string description);
        string GetDescription();
        void SetName(string name);
        string GetName();
        string ToString();
    }
}