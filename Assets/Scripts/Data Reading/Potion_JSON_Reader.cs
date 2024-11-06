using UnityEngine;
using UnityEngine.UI;

public class Potion_JSON_Reader : MonoBehaviour
{
    public TextAsset jsonFile;

    [System.Serializable]
    public class Ingredient
    {
        public string ingredient_name;
        public int quantity;
    }
    
    [System.Serializable]
    public class IngredientsList
    {
        public Ingredient[] ingredient;
    }
    
    [System.Serializable]
    public class Potion
    {
        public int id;
        public string name;
        public string description;
        public int tier;
        public IngredientsList ingredients;
        public int cost;
        public float grind_time;
        public float cook_time;
    }

    [System.Serializable]
    public class PotionList
    {
        public Potion[] potions;
    }
    
    public PotionList potionList = new PotionList();

    private void Start()
    {
        Debug.Log(jsonFile.text);
        potionList = JsonUtility.FromJson<PotionList>(jsonFile.text);
    }
}
