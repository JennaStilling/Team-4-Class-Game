using UnityEngine;

namespace Composite
{
    public class Quest : IQuest
    {
        private string _name { get; set; }
        private string _description { get; set; }
        private bool _isComplete;
        
        public Quest(string name, string description)
        {
            _name = name;
            _description = description;
            _isComplete = false;
        }

        public void CompleteQuest()
        {
            _isComplete = true;
            Debug.Log("Player has completed " + _name + " quest");
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

        public string ToString()
        {
            return "Quest Name: " + _name + ", Description: " + _description;
        }
    }
}