using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Jenna
{
    public class UI_ClickHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private float _touchFeedbackScale = 0.9f;
        [SerializeField] private float _touchFeedbackDuration = 0.1f;
        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;
        private bool _brewerToggled = false;
        private bool _recipeToggled = false;
        private Vector3 _originalScale;
        private float _touchStartTime;
        private const float TOUCH_THRESHOLD = 0.5f;
        private Image _buttonImage;
        private Color _originalColor;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
            _originalScale = transform.localScale;
            _buttonImage = GetComponent<Image>();
            if (_buttonImage != null)
            {
                _originalColor = _buttonImage.color;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _touchStartTime = Time.time;
            // Visual feedback for touch
            transform.localScale = _originalScale * _touchFeedbackScale;
            if (_buttonImage != null)
            {
                _buttonImage.color = new Color(_originalColor.r, _originalColor.g, _originalColor.b, _originalColor.a * 0.8f);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            // Reset visual feedback
            transform.localScale = _originalScale;
            if (_buttonImage != null)
            {
                _buttonImage.color = _originalColor;
            }

            // Only trigger if touch duration is within threshold
            if (Time.time - _touchStartTime <= TOUCH_THRESHOLD)
            {
                HandleButtonPress();
            }
        }

        private void HandleButtonPress()
        {
            switch (gameObject.name)
            {
                case "Pause":
                    PauseGame();
                    break;
                case "Toggle_Brewer":
                    ToggleBrewer();
                    break;
                case "Toggle_Recipe":
                    ToggleRecipe();
                    break;
                case "Grind":
                    GrindIngredients();
                    break;
                case "Brew":
                    BrewPotion();
                    break;
                default:
                    Debug.Log("No name found - clicked on: " + gameObject.name);
                    break;
            }

            // Play haptic feedback on mobile
            #if UNITY_IOS || UNITY_ANDROID
            if (SystemInfo.supportsVibration)
            {
                Handheld.Vibrate();
            }
            #endif
        }

        private void PauseGame()
        {
            GameManager.Instance.GamePaused = true;
            if (GameManager.Instance.RecipeInterfaceOpen)
            {
                GameObject pauseMenu = GameObject.Find("Canvas/Recipe_Overlay/Pause_Menu");
                pauseMenu.SetActive(true);
                pauseMenu.GetComponent<PauseMenuHandler>().PauseGame();
            }
            else
            {
                GameObject pauseMenu = GameObject.Find("Canvas/Order_Overlay/Pause_Menu");
                pauseMenu.SetActive(true);
                pauseMenu.GetComponent<PauseMenuHandler>().PauseGame();
            }
        }

        private void ToggleRecipe()
        {
            _recipeToggled = !_recipeToggled;
            _brewerToggled = false;
            GameManager.Instance.BrewingInterfaceOpen = _brewerToggled;
            GameManager.Instance.RecipeInterfaceOpen = _recipeToggled;
            
            GameObject.Find("Managers/Camera_Manager").GetComponent<CameraManager>().SwitchCameras();
            GameObject brewer = GameObject.Find("Canvas/Order_Overlay/Brewing_Interface");
            if (brewer != null)
                brewer.SetActive(_brewerToggled);
        }

        public void ToggleBrewer()
        {
            _brewerToggled = !_brewerToggled;
            _recipeToggled = false;
            GameManager.Instance.BrewingInterfaceOpen = _brewerToggled;
            GameManager.Instance.RecipeInterfaceOpen = _recipeToggled;
            
            GameObject.Find("Managers/Camera_Manager").GetComponent<CameraManager>().MainCamera();
            GameObject brewer = GameObject.Find("Canvas/Order_Overlay/Brewing_Interface");
            if (brewer != null)
                brewer.SetActive(_brewerToggled);
        }

        public void GrindIngredients()
        {
            UI_Potion potion = GetComponentInParent<UI_Potion>();

            if (potion != null)
            {
                potion.GrindIngredients();
            }
        }

        public void BrewPotion()
        {
            UI_Potion potion = GetComponentInParent<UI_Potion>();

            if (potion != null)
            {
                potion.BrewPotion();
            }
        }
    }
}