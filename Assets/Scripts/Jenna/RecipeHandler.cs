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

        void Awake()
        {
            ingredient_quantity_one.text = "";
            ingredient_quantity_two.text = "";
            ingredient_quantity_three.text = "";
            ingredient_quantity_four.text = "";
            
            ingredient_name_one.text = "";
            ingredient_name_two.text = "";
            ingredient_name_three.text = "";
            ingredient_name_four.text = "";
        
            Color currentColorOne = potion_one.color;
            currentColorOne.a = 0f;
            potion_one.color = currentColorOne;
        
            Color currentColorTwo = potion_two.color;
            currentColorTwo.a = 0f;
            potion_two.color = currentColorTwo;
            
            Color currentColorThree = potion_three.color;
            currentColorThree.a = 0f;
            potion_three.color = currentColorThree;
            
            Color currentColorFour = potion_four.color;
            currentColorFour.a = 0f;
            potion_four.color = currentColorFour;
        }
        
        public void ChangeId(int id)
        {
            currentPotionId = id;
            UpdateInformation();
        }

        public void UpdateInformation()
        {
            
        }
    }
}