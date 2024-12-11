using Composite;
using UnityEngine;
using UnityEngine.UI;

namespace Jenna
{
    public class Order_Slot : MonoBehaviour
    {
        public bool slotFull = false;
        private CompositeOrder _currentOrder = null;
        
        public void AssignOrder(CompositeOrder order)
        {
            _currentOrder = order;
            slotFull = true;
            Debug.Log("Order assigned: " + order.ToString());
            foreach (var subOrder in order.GetSubOrders())
            {
             Debug.Log(subOrder.ToString());   
            }
            GetComponent<Image>().color = Color.green;
        }

        public void UpdateOrder(UI_Potion potion)
        {
            
        }

        public CompositeOrder GetCurrentOrder()
        {
            return _currentOrder;
        }

        public void FinishOrder()
        {
            slotFull = false;
            Debug.Log("Order complete");
            _currentOrder = null;
        }
    }
}