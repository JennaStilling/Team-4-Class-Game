using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Jenna
{
    public class RecipeHandler : MonoBehaviour
    {
        public int currentPotionId = 1;
        
        [SerializeField] private TextMeshProUGUI potionName;
        [SerializeField] private TextMeshProUGUI potionDescription;
        
        [SerializeField] private TextMeshProUGUI ingredient_quantity_one;
        [SerializeField] private TextMeshProUGUI ingredient_quantity_two;
        [SerializeField] private TextMeshProUGUI ingredient_name_one;
        [SerializeField] private TextMeshProUGUI ingredient_name_two;
        [SerializeField] private Image potion_one;
        [SerializeField] private Image potion_two;
        
        [SerializeField] private TextMeshProUGUI ingredient_quantity_three;
        [SerializeField] private TextMeshProUGUI ingredient_quantity_four;
        [SerializeField] private TextMeshProUGUI ingredient_name_three;
        [SerializeField] private TextMeshProUGUI ingredient_name_four;
        [SerializeField] private Image potion_three;
        [SerializeField] private Image potion_four;

        private GameObject potions = null;
        private Dictionary<int, Potion_JSON_Reader.Potion> potionList = null;

        void Awake()
        {
            potionList = new Dictionary<int, Potion_JSON_Reader.Potion>();
            potions = GameObject.Find("Potion_Loader");
            potionList = potions.GetComponent<Potion_JSON_Reader>().GetPotionList();
            
            ClearUI();
        }
        
        public void ChangeId(int id)
        {
            currentPotionId = id;
            UpdateInformation();
        }

        public void UpdateInformation()
        {
            if (potionList.ContainsKey(currentPotionId))
            {
                Potion_JSON_Reader.Potion potion = potionList[currentPotionId];
                potionName.text = potion.name;
                potionDescription.text = potion.description;
                
                ClearIngredients();
                
                var ingredientTextures = GameObject.Find("Potion_Loader").GetComponent<IngredientMaterials>().GetIngredientTextures();
                List<Potion_JSON_Reader.Ingredient> ingredients = potion.ingredients.ingredient;
                
                if (ingredients.Count > 0) 
                    UpdateIngredientSlot(ingredients[0], ingredientTextures, 1);
                if (ingredients.Count > 1) 
                    UpdateIngredientSlot(ingredients[1], ingredientTextures, 2);
                if (ingredients.Count > 2) 
                    UpdateIngredientSlot(ingredients[2], ingredientTextures, 3);
                if (ingredients.Count > 3) 
                    UpdateIngredientSlot(ingredients[3], ingredientTextures, 4);
            }
            else
            {
                Debug.LogWarning("Potion with id " + currentPotionId + " not found.");
            }
        }

        private void UpdateIngredientSlot(Potion_JSON_Reader.Ingredient ingredient, Dictionary<int, Texture> ingredientTextures, int slotNum)
        {
            if (ingredientTextures.TryGetValue(ingredient.id, out Texture texture) && texture is Texture2D texture2D)
            {
                Rect rect = new Rect(0, 0, texture2D.width, texture2D.height);
                Sprite ingredientSprite = Sprite.Create(texture2D, rect, new Vector2(0.5f, 0.5f));
                switch (slotNum)
                {
                    case 1:
                        UpdateIngredientUI(potion_one, ingredient_quantity_one, ingredient_name_one, ingredient, ingredientSprite);
                        break;
                    case 2:
                        UpdateIngredientUI(potion_two, ingredient_quantity_two, ingredient_name_two, ingredient, ingredientSprite);
                        break;
                    case 3:
                        UpdateIngredientUI(potion_three, ingredient_quantity_three, ingredient_name_three, ingredient, ingredientSprite);
                        break;
                    case 4:
                        UpdateIngredientUI(potion_four, ingredient_quantity_four, ingredient_name_four, ingredient, ingredientSprite);
                        break;
                }
            }
        }

        private void UpdateIngredientUI(Image image, TextMeshProUGUI quantityText, TextMeshProUGUI nameText, Potion_JSON_Reader.Ingredient ingredient, Sprite sprite)
        {
            image.sprite = sprite;
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
            quantityText.text = ingredient.quantity.ToString();
            nameText.text = ingredient.ingredient_name;
            image.gameObject.SetActive(true);
        }


        private void ClearUI()
        {
            potionName.text = "";
            potionDescription.text = "";
            
            ClearIngredients();
        }

        private void ClearIngredients()
        {
            ingredient_quantity_one.text = "";
            ingredient_quantity_two.text = "";
            ingredient_quantity_three.text = "";
            ingredient_quantity_four.text = "";
            
            ingredient_name_one.text = "";
            ingredient_name_two.text = "";
            ingredient_name_three.text = "";
            ingredient_name_four.text = "";
            
            potion_one.gameObject.SetActive(false);
            potion_two.gameObject.SetActive(false);
            potion_three.gameObject.SetActive(false);
            potion_four.gameObject.SetActive(false);
        }
    }
}
