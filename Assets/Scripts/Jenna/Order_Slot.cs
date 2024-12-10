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
            GetComponent<Image>().color = Color.green;
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