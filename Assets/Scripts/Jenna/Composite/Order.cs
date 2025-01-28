using UnityEngine;

namespace Composite
{
    public class Order : IOrder
    {
        private string _name { get; set; }
        private string _description { get; set; }
        private bool _isComplete;
        private int _potionId;
        private int _quantity;

        public Order(int potionId, int quantity, string name, string description)
        {
            _potionId = potionId;
            _quantity = quantity;
            _name = name;
            _description = description;
            _isComplete = false;
        }

        public void CompleteQuest()
        {
            _isComplete = true;
        }

        public bool IsComplete()
        {
            return _isComplete;
        }

        public void SetDescription(string description)
        {
            _description = description;
        }

        public string GetDescription()
        {
            return _description;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetPotionId()
        {
            return _potionId; // Return the potion ID
        }

        public string ToString()
        {
            return "Potion ID: " + _potionId + " Description: " + _description;
        }

        public void SetOrderId(int id)
        {
            throw new System.NotImplementedException();
        }

        public int GetOrderId()
        {
            throw new System.NotImplementedException();
        }

        public void SetQuantity(int quantity)
        {
            _quantity = quantity;
        }

        public int GetQuantity()
        {
            return _quantity;
        }
    }
}