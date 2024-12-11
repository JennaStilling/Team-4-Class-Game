using Player_Potion_Making;
using UnityEngine;
using Composite;
using Jenna;

public class ClickToOrder : MonoBehaviour
{
    private bool _orderTaken = false;

    public void PerformAction()
    {
        if (!_orderTaken && !GameManager.Instance.BrewingInterfaceOpen && !GameManager.Instance.RecipeInterfaceOpen && !GameManager.Instance.GamePaused)
        {
            _orderTaken = true;

            GameObject orderBoard = GameObject.Find("Order_Board");
            GameObject ordersParent = GameObject.Find("Canvas/Order_Overlay/Orders/Sidebar");

            if (orderBoard != null && ordersParent != null)
            {
                Order_JSON_Reader orderReader = orderBoard.GetComponent<Order_JSON_Reader>();
                int orderIndex = orderReader.GenerateRandomOrder();
                var order = orderReader.GetPotionData()[orderIndex];

                CompositeOrder compositeOrder =
                    new CompositeOrder("Potion Order", "not really needed, something funny, etc.", orderIndex);
                Debug.Log("Number of potions in this order: " + order.potions.Count);

                foreach (var orderPotion in order.potions)
                {
                    Order potionOrder = new Order(orderPotion.id, orderPotion.quantity, "Potion ID " + orderPotion.id,
                        "Create " + orderPotion.quantity + " potions of ID " + orderPotion.id);
                    compositeOrder.AddSubOrder(potionOrder);
                }

                Debug.Log("Order created with " + compositeOrder.GetSubOrders().Count + " sub orders.");
                
                bool orderAssigned = false;

                foreach (Transform child in ordersParent.transform)
                {
                    Order_Slot slot = child.GetComponent<Order_Slot>();

                    if (slot != null && !slot.slotFull)
                    {
                        slot.AssignOrder(compositeOrder);
                        slot.RegisterSuccessListener(ResetOrderStatus);
                        orderAssigned = true;
                        break;
                    }
                }

                if (!orderAssigned)
                {
                    Debug.LogError("All order slots are full. Cannot assign a new order.");
                }

                GetComponent<Customer>().SetOrderId(orderIndex);
            }
            else
            {
                Debug.LogError("Order_Board or Orders object not found in the hierarchy.");
            }
        }
        else
        {
            Debug.Log("Order already taken from " + gameObject.name);
        }
    }

    public void ResetOrderStatus()
    {
        Debug.Log("Customer can now give another order!");
        _orderTaken = false;
    }
}