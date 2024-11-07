using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace Player_Potion_Making
{
    [System.Serializable]
    public class Order
    {
        public List<OrderPotion> potions;
        private int _profit = 0;

        public Order()
        {
            potions = new List<OrderPotion>();
            potions.Add(new OrderPotion(1, 2));
            potions.Add(new OrderPotion(2, 3));
            //CalculateProfit();
        }

        public void CalculateProfit()
        {
            foreach (var orderPotion in potions)
            {
                _profit += (Potion_JSON_Reader.Instance.GetPotionData()[orderPotion.id].cost * orderPotion.quantity);
                Debug.Log("Added potion - " + Potion_JSON_Reader.Instance.GetPotionData()[orderPotion.id].name + " with a cost of " + (Potion_JSON_Reader.Instance.GetPotionData()[orderPotion.id].cost * orderPotion.quantity));
            }
            Debug.Log(_profit);
        }
    }

    public class Orders : MonoBehaviour
    {
        public Dictionary<int, Order> orders;
        private int numOrders = 0;
        private int _profit;

        private void Start()
        {
            orders = new Dictionary<int, Order>();
            AddOrder(new Order());
        }

        public void AddOrder(Order order)
        {
            numOrders++;
            orders.Add(numOrders, order);
        }

        public void CompleteOrder()
        {
            
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                orders[1].CalculateProfit();
            }
        }
    }
}