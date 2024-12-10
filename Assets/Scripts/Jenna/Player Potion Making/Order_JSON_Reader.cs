using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player_Potion_Making
{
    public class Order_JSON_Reader : MonoBehaviour
    {
        public static Order_JSON_Reader Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    
        public TextAsset jsonFile;
        
        
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
                profit = 0;
                foreach (var orderPotion in potions)
                {
                    profit += (Potion_JSON_Reader.Instance.GetPotionData()[orderPotion.id].cost * orderPotion.quantity);
                    Debug.Log("Added potion - " + Potion_JSON_Reader.Instance.GetPotionData()[orderPotion.id].name +
                              " with a cost of " + (Potion_JSON_Reader.Instance.GetPotionData()[orderPotion.id].cost *
                                                    orderPotion.quantity));
                }

                Debug.Log("Total profit: " + profit);
            }

            public int GetProfit()
            {
                return profit;
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
        }

        [System.Serializable]
        public class OrderList
        {
            public List<Order> orders = new List<Order>();
        }
        
        public OrderList orderList = new OrderList();
    
        private Dictionary<int, Order> _orderData = new Dictionary<int, Order>();

        private void Start()
        {
            //Debug.Log(jsonFile.text);
            orderList = JsonUtility.FromJson<OrderList>(jsonFile.text);
            FillData();
        }

        private void FillData()
        {
            foreach (var order in orderList.orders)
            {
                _orderData.Add(order.id, order);
                //Debug.Log(_orderData[order.id].GetProfit());
            }
        }

        public Dictionary<int, Order> GetPotionData()
        {
            return _orderData;
        }
        
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                int i = Random.Range(0, 50);
                Debug.Log("Order id: " + _orderData[i].id);
                _orderData[i].CalculateProfit();
            }
        }

        public void GenerateRandomOrder()
        {
            int i = Random.Range(0, 50);
            Debug.Log("Order id: " + _orderData[i].id);
            _orderData[i].CalculateProfit();
        }
    }
    
}