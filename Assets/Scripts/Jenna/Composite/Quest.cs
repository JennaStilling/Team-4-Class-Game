using UnityEngine;

namespace Composite
{
    public class Quest : IQuest
    {
        private string _name { get; set; }
        private string _description { get; set; }
        private bool _isComplete;
        private int _potionId; // Track potion ID

        public Quest(int potionId, string name, string description)
        {
            _potionId = potionId; // Initialize with potion ID
            _name = name;
            _description = description;
            _isComplete = false;
        }

        public void CompleteQuest()
        {
            _isComplete = true;
            Debug.Log("Potion " + _potionId + " quest completed: " + _name);
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
            return "Potion ID: " + _potionId + ", Quest Name: " + _name + ", Description: " + _description;
        }
    }
}