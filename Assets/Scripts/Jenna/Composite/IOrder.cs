namespace Composite
{
    public interface IOrder
    {
        void CompleteQuest();
        bool IsComplete();
        void SetDescription(string description);
        string GetDescription();
        void SetName(string name);
        string GetName();
        int GetPotionId();
        string ToString();
        void SetOrderId(int id);
        int GetOrderId();
        void SetQuantity(int quantity);
        int GetQuantity();
    }
}