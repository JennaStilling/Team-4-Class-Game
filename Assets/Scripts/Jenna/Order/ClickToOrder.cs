using Player_Potion_Making;
using UnityEngine;
using Composite;
using Jenna;

public class ClickToOrder : MonoBehaviour
{
    private bool _orderTaken = false;

    public void PerformAction()
    {
        if (!_orderTaken)
        {
            _orderTaken = true;
            // Debug.Log("Action performed on " + gameObject.name);
            GameObject orderBoard = GameObject.Find("Order_Board");

            if (orderBoard != null)
            {
                Order_JSON_Reader orderReader = orderBoard.GetComponent<Order_JSON_Reader>();
                int orderIndex = orderReader.GenerateRandomOrder();
                var order = orderReader.GetPotionData()[orderIndex];

                CompositeOrder compositeOrder =
                    new CompositeOrder("Potion Order", "not really needed, something funny, etc.", orderIndex);
                Debug.Log("Number of potions in this order: " + order.potions.Count);

                foreach (var orderPotion in order.potions)
                {
                    Order potionOrder = new Order(orderPotion.id, "Potion ID " + orderPotion.id,
                        "Create " + orderPotion.quantity + " potions of ID " + orderPotion.id);
                    compositeOrder.AddSubOrder(potionOrder);
                }

                Debug.Log("Order created with " + compositeOrder.GetSubOrders().Count + " sub orders.");

                foreach (var subOrder in compositeOrder.GetSubOrders())
                {
                    Debug.Log(subOrder.ToString());
                }
                
                GetComponent<Customer>().SetOrderId(orderIndex);
            }

            else
            {
                Debug.Log("Order_Board object not found.");
            }
        }
        else {
            Debug.Log("Order taken already from " + gameObject.name);
        }
    }
}