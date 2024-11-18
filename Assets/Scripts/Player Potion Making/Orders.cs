using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace Player_Potion_Making
{
    [System.Serializable]
    public class OrderPotion
    {
        public int id;
        public int quantity;

        public OrderPotion()
        {
            id = 1;
            quantity = 1;
        }

        public OrderPotion(int id, int quantity)
        {
            this.id = id;
            this.quantity = quantity;
        }
    }
    [System.Serializable]
    public class Order
    {
        public int id;
        public int profit = 0;
        public List<OrderPotion> potions;
        public int day_unlocked;


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
                profit += (Potion_JSON_Reader.Instance.GetPotionData()[orderPotion.id].cost * orderPotion.quantity);
                Debug.Log("Added potion - " + Potion_JSON_Reader.Instance.GetPotionData()[orderPotion.id].name + " with a cost of " + (Potion_JSON_Reader.Instance.GetPotionData()[orderPotion.id].cost * orderPotion.quantity));
            }
            Debug.Log(profit);
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