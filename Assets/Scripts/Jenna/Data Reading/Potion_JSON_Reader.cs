using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potion_JSON_Reader : MonoBehaviour
{
    public static Potion_JSON_Reader Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public TextAsset jsonFile;

    [System.Serializable]
    public class Ingredient
    {
        public string ingredient_name;
        public int id;
        public int quantity;
    }
    
    [System.Serializable]
    public class IngredientsList
    {
        public List<Ingredient> ingredient = new List<Ingredient>();
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
        public List<Potion> potions = new List<Potion>();
    }
    
    public PotionList potionList = new PotionList();
    
    private Dictionary<int, Potion> _potionData = new Dictionary<int, Potion>();

    private void Start()
    {
        //Debug.Log(jsonFile.text);
        potionList = JsonUtility.FromJson<PotionList>(jsonFile.text);
        FillData();
    }

    private void FillData()
    {
        foreach (var potion in potionList.potions)
        {
            _potionData.Add(potion.id, potion);
            //Debug.Log(_potionData[potion.id].name);
        }
    }

    public Dictionary<int, Potion> GetPotionData()
    {
        return _potionData;
    }

    public Dictionary<int, Potion> GetPotionList()
    {
        return _potionData;
    }

    public Potion GetPotionById(int id)
    {
        return _potionData[id];
    }
}
