using Player_Potion_Making;
using UnityEngine;

public class ClickToOrder : MonoBehaviour
{
    public void PerformAction()
    {
        Debug.Log("Action performed on " + gameObject.name);
        GameObject orderBoard = GameObject.Find("Order_Board");

        // Check if the object exists in the scene
        if (orderBoard != null)
        {
            orderBoard.GetComponent<Order_JSON_Reader>().GenerateRandomOrder();
        }
        else
        {
            Debug.Log("Order_Board object not found.");
        }
    }
}
