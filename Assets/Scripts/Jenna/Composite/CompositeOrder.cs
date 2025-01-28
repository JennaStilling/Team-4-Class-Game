using System.Collections.Generic;
using Jenna;
using UnityEngine;
using UnityEngine.Events;

namespace Composite
{
    public class CompositeOrder : IOrder
    {
        [SerializeField] private UnityEvent onTransmitSuccess = new UnityEvent();
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
                    return;
                }
            }

            SoundManager.Instance.PlayEffect(AudioTag.Complete);
            GameManager.Instance.OrdersComplete++;
            _isComplete = true;
            TransmitSuccess();
        }

        public void TransmitSuccess()
        {
            onTransmitSuccess.Invoke();
        }
        
        public void RegisterSuccessListener(UnityAction listener)
        {
            onTransmitSuccess.AddListener(listener);
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

        public void SetQuantity(int quantity)
        {
            throw new System.NotImplementedException();
        }

        public int GetQuantity()
        {
            throw new System.NotImplementedException();
        }

        public void AddPotionToOrder(int potionId)
        {
            bool addedPotion = false;
            foreach (var order in _subOrders)
            {
                if (potionId == order.GetPotionId())
                {
                    order.SetQuantity(order.GetQuantity() - 1);
                    Debug.Log("Added potion to order.");
                    addedPotion = true;
                    if (order.GetQuantity() <= 0)
                    {
                        order.CompleteQuest();
                        CompleteQuest();
                    }
                }
            }

            if (!addedPotion)
            {
                Debug.Log("Potion not needed - failed order");
                SoundManager.Instance.PlayEffect(AudioTag.Error);
                GameManager.Instance.OrdersRuined++;
                onTransmitSuccess.Invoke();
            }
        }
    }
}