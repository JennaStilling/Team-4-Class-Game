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
            int i = 0;
            
            foreach (var subOrder in order.GetSubOrders())
            {
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
            GetComponent<Image>().color = Color.white;
            slotFull = false;
            GetComponent<OrderSlotHandler>().ResetCard();
            Debug.Log("Order complete");
            _currentOrder = null;
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

        public CompositeOrder GetCurrentOrder()
        {
            return _currentOrder;
        }
    }
}