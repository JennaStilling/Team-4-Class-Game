using UnityEngine;
using UnityEngine.EventSystems;

namespace Jenna
{
    public class DragDropUI : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] private Canvas _canvas;
        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;
        private GameObject _draggingObject;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public GameObject GetDraggingObject()
        {
            return _draggingObject;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            // You can add logic for handling the initial click here if needed.
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            // Instantiate a new copy of the object to drag
            _draggingObject = Instantiate(gameObject, _canvas.transform);
            RectTransform draggingRectTransform = _draggingObject.GetComponent<RectTransform>();

            // Make sure the copy is the same size as the original
            draggingRectTransform.sizeDelta = _rectTransform.sizeDelta;
            draggingRectTransform.position = _rectTransform.position;

            // Disable raycast blocking so the copy doesn't block other UI elements
            CanvasGroup draggingCanvasGroup = _draggingObject.GetComponent<CanvasGroup>();
            if (draggingCanvasGroup != null)
            {
                draggingCanvasGroup.blocksRaycasts = false;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (_draggingObject != null)
            {
                //Debug.Log("OnEndDrag");

                // Destroy the dragging object (the copy)
                Destroy(_draggingObject);
            }

            _canvasGroup.blocksRaycasts = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_draggingObject != null)
            {
                // Move the copied object with the mouse pointer
                RectTransform draggingRectTransform = _draggingObject.GetComponent<RectTransform>();
                draggingRectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
            }
        }
    }
}
