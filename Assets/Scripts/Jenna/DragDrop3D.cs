using UnityEngine;
using UnityEngine.EventSystems;

namespace Jenna
{
    public class DragDrop3D : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private Transform _transform;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            Debug.Log("awake");
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("OnPointerDown");
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("OnBeginDrag");
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("OnEndDrag");
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("OnDrag");

            // Get the current screen position of the object
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(_transform.position);

            // Update the screen position based on drag delta
            screenPosition.y += eventData.delta.y;
            screenPosition.z += eventData.delta.x; // Use delta.x for Z movement in world space

            // Convert the updated screen position back to world space
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

            // Apply the new position, keeping the X axis fixed
            _transform.position = new Vector3(
                _transform.position.x, // Keep X fixed
                worldPosition.y,       // Update Y position
                worldPosition.z        // Update Z position
            );
        }




    }
}