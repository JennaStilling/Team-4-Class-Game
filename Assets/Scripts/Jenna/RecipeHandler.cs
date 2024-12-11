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
                
                List<Potion_JSON_Reader.Ingredient> ingredients = potion.ingredients.ingredient;
                
                if (ingredients.Count > 0)
                {
                    ingredient_name_one.text = ingredients[0].ingredient_name;
                    ingredient_quantity_one.text = ingredients[0].quantity.ToString();
                    potion_one.gameObject.SetActive(true);
                }

                if (ingredients.Count > 1)
                {
                    ingredient_name_two.text = ingredients[1].ingredient_name;
                    ingredient_quantity_two.text = ingredients[1].quantity.ToString();
                    potion_two.gameObject.SetActive(true);
                }

                if (ingredients.Count > 2)
                {
                    ingredient_name_three.text = ingredients[2].ingredient_name;
                    ingredient_quantity_three.text = ingredients[2].quantity.ToString();
                    potion_three.gameObject.SetActive(true);
                }

                if (ingredients.Count > 3)
                {
                    ingredient_name_four.text = ingredients[3].ingredient_name;
                    ingredient_quantity_four.text = ingredients[3].quantity.ToString();
                    potion_four.gameObject.SetActive(true);
                }
            }
            else
            {
                Debug.LogWarning("Potion with id " + currentPotionId + " not found.");
            }
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
