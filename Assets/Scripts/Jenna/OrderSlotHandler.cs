using Composite;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Jenna
{
    public class OrderSlotHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI quantity_one;
        [SerializeField] private TextMeshProUGUI quantity_two;
        [SerializeField] private Image potion_one;
        [SerializeField] private Image potion_two;
        private bool _hasCurrentOrder = false;
        private CompositeOrder _currentOrder = null;


        void Awake()
        {
            quantity_one.text = "";
            quantity_two.text = "";
            
            Color currentColorOne = potion_one.color;
            currentColorOne.a = 0f;
            potion_one.color = currentColorOne;
            
            Color currentColorTwo = potion_two.color;
            currentColorTwo.a = 0f;
            potion_two.color = currentColorTwo;
        }

        public void SetCurrentOrder(CompositeOrder order)
        {
            _currentOrder = order;
        }
        public void UpdateCardImages(int potionId, int slotNum)
        {
            _hasCurrentOrder = true;
            Texture potion =
                GameObject.Find("Potion_Loader").GetComponent<PotionMaterials>().GetPotionMaterials()[potionId];
            
            if (potion is Texture2D texture2D)
            {
                Rect rect = new Rect(0, 0, texture2D.width, texture2D.height);
                Sprite potionSprite = Sprite.Create(texture2D, rect, new Vector2(0.5f, 0.5f));
                if (slotNum == 1)
                {
                    potion_one.sprite = potionSprite;
                    
                    Color currentColorOne = potion_one.color;
                    currentColorOne.a = 1f;
                    potion_one.color = currentColorOne;
                }
                else if (slotNum == 2)
                {
                    potion_two.sprite = potionSprite;
                    
                    Color currentColorTwo = potion_two.color;
                    currentColorTwo.a = 1f;
                    potion_two.color = currentColorTwo;
                }
            }
            else
            {
                Debug.LogError("Failed to convert potion material texture to Texture2D.");
            }
        }
        
        public void UpdateCardQuantities(int quantity, int slotNum)
        {
            _hasCurrentOrder = true;
            if (slotNum == 1)
            {
                quantity_one.text = quantity.ToString();
            }
            else if (slotNum == 2)
            {
                quantity_two.text = quantity.ToString();
            }
        }

        public void ResetCard()
        {
            _hasCurrentOrder = false;
            quantity_one.text = "";
            quantity_two.text = "";
            
            Color currentColorOne = potion_one.color;
            currentColorOne.a = 0f;
            potion_one.color = currentColorOne;
            
            Color currentColorTwo = potion_two.color;
            currentColorTwo.a = 0f;
            potion_two.color = currentColorTwo;
        }
        
        public void Update()
        {
            if (_hasCurrentOrder)
            {
                int i = 0;
                foreach (var subOrder in _currentOrder.GetSubOrders())
                {
                    if (i <= 0)
                    {
                        GetComponent<OrderSlotHandler>().UpdateCardQuantities(subOrder.GetQuantity(), 1);
                    }
                    else
                    {
                        GetComponent<OrderSlotHandler>().UpdateCardQuantities(subOrder.GetQuantity(), 2);
                    }

                    i++;
                }
            }
        }
    }
}