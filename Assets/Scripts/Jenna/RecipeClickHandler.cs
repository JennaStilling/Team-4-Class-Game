using UnityEngine;
using UnityEngine.EventSystems;

namespace Jenna
{
    public class RecipeClickHandler : MonoBehaviour, IPointerDownHandler
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
            SoundManager.Instance.PlayEffect(AudioTag.Recipe);
            switch (gameObject.name)
            {
                case "Health":
                    GameObject.Find("Canvas/Recipe_Overlay/Potions").GetComponent<RecipeHandler>().currentPotionId = 1;
                    GameObject.Find("Canvas/Recipe_Overlay/Potions").GetComponent<RecipeHandler>().UpdateInformation();
                    break;
                case "Poison":
                    GameObject.Find("Canvas/Recipe_Overlay/Potions").GetComponent<RecipeHandler>().currentPotionId = 2;
                    GameObject.Find("Canvas/Recipe_Overlay/Potions").GetComponent<RecipeHandler>().UpdateInformation();
                    break;
                case "Mana":
                    GameObject.Find("Canvas/Recipe_Overlay/Potions").GetComponent<RecipeHandler>().currentPotionId = 3;
                    GameObject.Find("Canvas/Recipe_Overlay/Potions").GetComponent<RecipeHandler>().UpdateInformation();
                    break;
                case "Strength":
                    GameObject.Find("Canvas/Recipe_Overlay/Potions").GetComponent<RecipeHandler>().currentPotionId = 4;
                    GameObject.Find("Canvas/Recipe_Overlay/Potions").GetComponent<RecipeHandler>().UpdateInformation();
                    break;
                case "Speed":
                    GameObject.Find("Canvas/Recipe_Overlay/Potions").GetComponent<RecipeHandler>().currentPotionId = 5;
                    GameObject.Find("Canvas/Recipe_Overlay/Potions").GetComponent<RecipeHandler>().UpdateInformation();
                    break;
                case "Night Vision":
                    GameObject.Find("Canvas/Recipe_Overlay/Potions").GetComponent<RecipeHandler>().currentPotionId = 6;
                    GameObject.Find("Canvas/Recipe_Overlay/Potions").GetComponent<RecipeHandler>().UpdateInformation();
                    break;
                case "Fire Resistance":
                    GameObject.Find("Canvas/Recipe_Overlay/Potions").GetComponent<RecipeHandler>().currentPotionId = 7;
                    GameObject.Find("Canvas/Recipe_Overlay/Potions").GetComponent<RecipeHandler>().UpdateInformation();
                    break;
                case "Water Breathing":
                    GameObject.Find("Canvas/Recipe_Overlay/Potions").GetComponent<RecipeHandler>().currentPotionId = 8;
                    GameObject.Find("Canvas/Recipe_Overlay/Potions").GetComponent<RecipeHandler>().UpdateInformation();
                    break;
                case "Climbing":
                    GameObject.Find("Canvas/Recipe_Overlay/Potions").GetComponent<RecipeHandler>().currentPotionId = 9;
                    GameObject.Find("Canvas/Recipe_Overlay/Potions").GetComponent<RecipeHandler>().UpdateInformation();
                    break;
                case "Invisibility":
                    GameObject.Find("Canvas/Recipe_Overlay/Potions").GetComponent<RecipeHandler>().currentPotionId = 10;
                    GameObject.Find("Canvas/Recipe_Overlay/Potions").GetComponent<RecipeHandler>().UpdateInformation();
                    break;
                case "Invulnerability":
                    GameObject.Find("Canvas/Recipe_Overlay/Potions").GetComponent<RecipeHandler>().currentPotionId = 11;
                    GameObject.Find("Canvas/Recipe_Overlay/Potions").GetComponent<RecipeHandler>().UpdateInformation();
                    break;
                default:
                    Debug.Log("No name found - clicked on: " + gameObject.name);
                    break;
            }
        }


    }
}