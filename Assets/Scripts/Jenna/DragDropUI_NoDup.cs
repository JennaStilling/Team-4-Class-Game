using UnityEngine;
using UnityEngine.EventSystems;

namespace Jenna
{
    public class DragDropUI_NoDup : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] private Canvas _canvas;
        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_canvasGroup != null)
            {
                _canvasGroup.blocksRaycasts = false;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (_canvasGroup != null)
            {
                _canvasGroup.blocksRaycasts = true;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }
    }
}