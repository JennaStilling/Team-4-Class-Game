using System.Collections.Generic;
using UnityEngine;

namespace Composite
{
    public class CompositeOrder : IOrder
    {
        private string _name { get; set; }
        private string _description { get; set; }
        private bool _isComplete;
        private List<IOrder> _subOrders { get; set; }
        private int _id;

        public CompositeOrder(string name, string description, int id)
        {
            _name = name;
            _description = description;
            _isComplete = false;
            _subOrders = new List<IOrder>();
            _id = id;
        }

        public void CompleteQuest()
        {
            foreach (var subQuest in _subOrders)
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

        public int GetPotionId()
        {
            throw new System.NotImplementedException();
        }

        public void AddSubOrder(IOrder subOrders)
        {
            _subOrders.Add(subOrders);
        }

        public void RemoveSubOrder(IOrder subOrders)
        {
            _subOrders.Remove(subOrders);
        }

        public List<IOrder> GetSubOrders()
        {
            return _subOrders;
        }

        public string ToString()
        {
            return "Composite Order Name: " + _name + ", Description: " + _description;
        }

        public void SetOrderId(int id)
        {
            _id = id;
        }

        public int GetOrderId()
        {
            return _id;
        }
    }
}