using UnityEngine;

namespace Jenna
{
    public class Customer : MonoBehaviour
    {
        [SerializeField] private int _orderId;

        public void SetOrderId(int id)
        {
            _orderId = id;
        }

        public int GetOrderId()
        {
            return _orderId;
        }
    }
}