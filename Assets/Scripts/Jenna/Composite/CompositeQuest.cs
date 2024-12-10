using System.Collections.Generic;
using UnityEngine;

namespace Composite
{
    public class CompositeQuest : IQuest
    {
        private string _name { get; set; }
        private string _description { get; set; }
        private bool _isComplete;
        private List<IQuest> _subQuests { get; set; }

        public CompositeQuest(string name, string description)
        {
            _name = name;
            _description = description;
            _isComplete = false;
            _subQuests = new List<IQuest>();
        }

        public void CompleteQuest()
        {
            foreach (var subQuest in _subQuests)
            {
                if (!subQuest.IsComplete())
                {
                    Debug.Log(_name + " is not completed as subquests have not been completed");
                    return;
                }
            }

            _isComplete = true;
            Debug.Log("Large quest complete");
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

        public List<IQuest> GetSubQuests()
        {
            return _subQuests;
        }

        public void AddSubquest(IQuest subQuest)
        {
            _subQuests.Add(subQuest);
        }

        public void RemoveSubquest(IQuest subQuest)
        {
            _subQuests.Remove(subQuest);

        }

        public string ToString()
        {
            return "Quest Name: " + _name + ", Description: " + _description;
        }
    }
}