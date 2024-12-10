using UnityEngine;
using UnityEngine.EventSystems;
using Player_Potion_Making;

namespace Jenna
{
    public class ItemSlot_NoDup : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            { 
                // logic for completing subquest
                // Add the ingredient to the potion reference (this part remains the same)
                UI_Potion potionReference = GetComponent<UI_Potion>();
                potionReference.AddIngredient(eventData.pointerDrag.GetComponent<Ingredient>().GetId());
            }
        }
    }
}