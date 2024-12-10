using UnityEngine;
using UnityEngine.EventSystems;
using Player_Potion_Making;

namespace Jenna
{
    public class ItemSlot : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            //Debug.Log("OnDrop");

            if (eventData.pointerDrag != null)
            {
                UI_Potion potionReference = GetComponent<UI_Potion>();
                potionReference.AddIngredient(eventData.pointerDrag.GetComponent<Ingredient>().GetId());
                
                // Get the dragging object reference from the DragDropUI component
                DragDropUI dragDropUI = eventData.pointerDrag.GetComponent<DragDropUI>();
                if (dragDropUI != null)
                {
                    GameObject draggingObject = dragDropUI.GetDraggingObject();
                    if (draggingObject != null)
                    {
                        Destroy(draggingObject); // Destroy the copy instead of the original
                    }
                }
            }
        }
    }
}