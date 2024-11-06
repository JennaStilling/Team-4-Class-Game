using UnityEngine;
using UnityEngine.UI;

public class Potion_JSON_Reader : MonoBehaviour
{
    public TextAsset jsonFile;
    [System.Serializable]
    public class Potion
    {
        public int id;
        public string name;
        public string description;
        public int tier;
        public int cost;
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

[System.Serializable]
public class PotionData
{
    public int id;
    public string name;
}

[System.Serializable]
public class IngredientData
{
    
}