using Player_Potion_Making;
using UnityEngine;
using Composite;

public class ClickToOrder : MonoBehaviour
{
    public void PerformAction()
    {
        // Debug.Log("Action performed on " + gameObject.name);
        GameObject orderBoard = GameObject.Find("Order_Board");

        if (orderBoard != null)
        {
            Order_JSON_Reader orderReader = orderBoard.GetComponent<Order_JSON_Reader>();
            int orderIndex = orderReader.GenerateRandomOrder();
            var order = orderReader.GetPotionData()[orderIndex]; 
            
            CompositeQuest compositeQuest = new CompositeQuest("Potion Order", "not really needed, something funny, etc.");
            Debug.Log("Number of potions in this order: " + order.potions.Count);
            
            foreach (var orderPotion in order.potions)
            {
                Quest potionQuest = new Quest(orderPotion.id, "Potion ID " + orderPotion.id, 
                    "Create " + orderPotion.quantity + " potions of ID " + orderPotion.id);
                compositeQuest.AddSubquest(potionQuest);
            }

            Debug.Log("Order created with " + compositeQuest.GetSubQuests().Count + " sub orders.");
        }
        else
        {
            Debug.Log("Order_Board object not found.");
        }
    }
}