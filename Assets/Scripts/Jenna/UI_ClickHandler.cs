using UnityEngine;
using UnityEngine.EventSystems;

namespace Jenna
{
    public class UI_ClickHandler : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Canvas _canvas;
        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;
        private bool _brewerToggled = false;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        

        public void OnPointerDown(PointerEventData eventData)
        {
            switch (gameObject.name)
            {
                case "Pause":
                    Debug.Log("Pause game");
                    break;
                case "Toggle_Brewer":
                    Debug.Log("Toggle Brewer");
                    ToggleBrewer();
                    break;
                default:
                    Debug.Log("No name found - clicked on: " + gameObject.name);
                    break;
            }
        }

        public void ToggleBrewer()
        {
            GameObject brewer = GameObject.Find("Canvas/Order_Overlay/Brewing_Interface");
            _brewerToggled = !_brewerToggled;
            brewer.SetActive(_brewerToggled);
            Debug.Log(_brewerToggled);
        }
    }
}