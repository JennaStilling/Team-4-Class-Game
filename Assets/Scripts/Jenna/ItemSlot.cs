using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Jenna
{
    public class ItemSlot : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("OnDrop");
            if (eventData.pointerDrag != null)
            {
               Destroy(eventData.pointerDrag);
               
               Image image = GetComponent<Image>();
               if (image != null)
               {
                   image.color = Color.green;
               }
               else
               {
                   Debug.Log("was null");
               }
            }
        }
    }
}