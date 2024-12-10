using UnityEngine;
using UnityEngine.EventSystems;
using Player_Potion_Making;
using Composite;

namespace Jenna
{
    public class ItemSlot_NoDup : MonoBehaviour, IDropHandler
    {
        // Reference to the CompositeQuest (could be set via inspector or dynamically)
        public CompositeOrder compositeQuest;

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                GameObject draggedItem = eventData.pointerDrag;
                UI_Potion draggedPotion = draggedItem.GetComponent<UI_Potion>();
                if (draggedPotion != null)
                {
                    int draggedPotionId = draggedPotion.GetPotionId();
                    foreach (var subquest in compositeQuest.GetSubOrders())
                    {
                        if (subquest.GetPotionId() == draggedPotionId)
                        {
                            subquest.CompleteQuest();
                            Debug.Log("Subquest with potion ID " + draggedPotionId + " completed!");
                            return;
                        }
                    }
                    
                    Debug.Log("No matching subquest for potion ID " + draggedPotionId);
                    Destroy(eventData.pointerDrag);
                }
                else
                {
                    Debug.LogError("Dragged item does not have a UI_Potion component.");
                    Destroy(eventData.pointerDrag);
                }
            }
        }
    }
}