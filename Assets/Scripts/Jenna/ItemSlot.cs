using Composite;
using UnityEngine;
using UnityEngine.EventSystems;
using Player_Potion_Making;

namespace Jenna
{
    public class ItemSlot : MonoBehaviour, IDropHandler
    {
        private DragDropUI dragDropUI = null;
        private GameObject draggingObject = null;
        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log(eventData.pointerDrag.name);

            if (eventData.pointerDrag != null && !eventData.pointerDrag.name.Equals("UI_PotionBrewing"))
            {
                UI_Potion potionReference = GetComponent<UI_Potion>();
                potionReference.AddIngredient(eventData.pointerDrag.GetComponent<Ingredient>().GetId());
                
                dragDropUI = eventData.pointerDrag.GetComponent<DragDropUI>();
                if (dragDropUI != null)
                {
                    draggingObject = dragDropUI.GetDraggingObject();
                    if (draggingObject != null)
                    {
                        Destroy(draggingObject);

                    }
                }
            }
            else if (eventData.pointerDrag != null && eventData.pointerDrag.name.Equals("UI_PotionBrewing"))
            {
                dragDropUI = eventData.pointerDrag.GetComponent<DragDropUI>();
                if (dragDropUI != null)
                {
                    draggingObject = dragDropUI.GetDraggingObject();
                    HandleOrderPotion();
                    draggingObject = dragDropUI.GetDraggingObject();
                    if (draggingObject != null)
                    {
                        Destroy(draggingObject);

                    }
                }
            }
            else
            {
                Debug.Log("Unimplemented");
            }
        }

        public void HandleOrderPotion()
        {
            CompositeOrder assignedOrder = GetComponent<Order_Slot>().GetCurrentOrder();
            assignedOrder.AddPotionToOrder(draggingObject.GetComponent<UI_Potion>().GetPotionId());
        }
    }
}