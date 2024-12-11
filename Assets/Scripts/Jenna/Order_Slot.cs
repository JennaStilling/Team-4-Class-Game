using Composite;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Jenna
{
    public class Order_Slot : MonoBehaviour
    {
        public bool slotFull = false;
        private CompositeOrder _currentOrder = null;
        [SerializeField] private UnityEvent onTransmitSuccess = new UnityEvent();
        
        public void AssignOrder(CompositeOrder order)
        {
            _currentOrder = order;
            _currentOrder.RegisterSuccessListener(FreeSlot); // Subscribe to the event
            GetComponent<OrderSlotHandler>().SetCurrentOrder(_currentOrder);
            slotFull = true;
            Debug.Log("Order assigned: " + order.ToString());
            int i = 0;
            
            foreach (var subOrder in order.GetSubOrders())
            {
                 Debug.Log(subOrder.ToString());
                 Debug.Log(i);
                 if (i == 0)
                 {
                     GetComponent<OrderSlotHandler>().UpdateCardImages(subOrder.GetPotionId(), 1);
                     GetComponent<OrderSlotHandler>().UpdateCardQuantities(subOrder.GetQuantity(), 1);
                 }
                 else if (i == 1)
                 {
                     GetComponent<OrderSlotHandler>().UpdateCardImages(subOrder.GetPotionId(), 2);
                     GetComponent<OrderSlotHandler>().UpdateCardQuantities(subOrder.GetQuantity(), 2);
                 }

                 i++;
            }
        }

        private void FreeSlot()
        {
            Debug.Log("Slot is now free!");
            GetComponent<Image>().color = Color.white;
            slotFull = false;
            GetComponent<OrderSlotHandler>().ResetCard();
            TransmitSuccess();
        }
        
        public void TransmitSuccess()
        {
            Debug.Log("Transmitting message that new order can be generated...");
            onTransmitSuccess.Invoke();
        }
        
        public void RegisterSuccessListener(UnityAction listener)
        {
            onTransmitSuccess.AddListener(listener);
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