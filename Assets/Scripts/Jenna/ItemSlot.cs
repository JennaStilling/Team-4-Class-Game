using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Player_Potion_Making;

namespace Jenna
{
    public class ItemSlot : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("OnDrop");
            if (eventData.pointerDrag != null)
            {
                UI_Potion potionReference = GetComponent<UI_Potion>();
                potionReference.AddIngredient(eventData.pointerDrag.GetComponent<Ingredient>().GetId());
               Destroy(eventData.pointerDrag);
               
               // Image image = GetComponent<Image>();
               // if (image != null)
               // {
               //     image.color = Color.green;
               // }
               // else
               // {
               //     Debug.Log("was null");
               // }
            }
        }
    }
}