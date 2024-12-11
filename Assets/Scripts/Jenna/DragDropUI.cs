using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

        public void SetCanvas(Canvas canvas)
        {
            _canvas = canvas;
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
//            Debug.Log(_draggingObject.name);
            if (_draggingObject.name.Equals("UI_PotionBrewing(Clone)"))
            {
                foreach (Transform child in _draggingObject.transform)
                {
                    Destroy(child.gameObject);
                }
            }

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

            if (gameObject.name.Equals("UI_PotionBrewing"))
            {
                Texture potionTexture = GetComponent<UI_Potion>().GetDefaultTexture();
            
                if (potionTexture is Texture2D texture2D)
                {
                    Rect rect = new Rect(0, 0, texture2D.width, texture2D.height);
                    Sprite potionSprite = Sprite.Create(texture2D, rect, new Vector2(0.5f, 0.5f));
                    GetComponent<Image>().sprite = potionSprite;

                    gameObject.AddComponent<DragDropUI>();
                    GetComponent<DragDropUI>().SetCanvas(GameObject.Find("Canvas").GetComponent<Canvas>());
                }
                else
                {
                    Debug.LogError("Failed to convert potion material texture to Texture2D.");
                }
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
