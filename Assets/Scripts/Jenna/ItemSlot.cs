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
            if (eventData.pointerDrag != null && !eventData.pointerDrag.name.Equals("UI_PotionBrewing"))
            {
                SoundManager.Instance.PlayEffect(AudioTag.Drag);
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
                    HandleOrderPotion( eventData);
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

        public void HandleOrderPotion(PointerEventData eventData)
        {
            CompositeOrder assignedOrder = GetComponent<Order_Slot>().GetCurrentOrder();
            assignedOrder.AddPotionToOrder(draggingObject.GetComponent<UI_Potion>().GetPotionId());
            SoundManager.Instance.PlayEffect(AudioTag.Drag);
            eventData.pointerDrag.GetComponent<UI_Potion>().ResetPotion();
        }
    }
}