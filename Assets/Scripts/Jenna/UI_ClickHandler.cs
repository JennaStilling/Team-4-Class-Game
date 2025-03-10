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
        private bool _recipeToggled = false;

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