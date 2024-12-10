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
            // Debug.Log("OnPointerDown");
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _draggingObject = Instantiate(gameObject, _canvas.transform);
            RectTransform draggingRectTransform = _draggingObject.GetComponent<RectTransform>();

            draggingRectTransform.sizeDelta = _rectTransform.sizeDelta;
            draggingRectTransform.position = _rectTransform.position;
            
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
                Destroy(_draggingObject);
            }

            _canvasGroup.blocksRaycasts = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_draggingObject != null)
            {
                RectTransform draggingRectTransform = _draggingObject.GetComponent<RectTransform>();
                draggingRectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
            }
        }
    }
}
