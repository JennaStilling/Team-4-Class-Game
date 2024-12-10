using System;
using System.Collections.Generic;
using Data_Reading;
using UnityEngine;
using System.Linq; // Add this at the top of your file

namespace Jenna
{
    [Serializable]
    public enum PotionState
    {
        Empty,
        Ground,
        Brewed,
        Failed
    }
    
    public class UI_Potion : MonoBehaviour
    {
        private List<int> _currentIngredients;
        [SerializeField] private int _potionId;
        private PotionState _currentState;
        private Dictionary<int, Potion_JSON_Reader.Potion> _allPotionList;
        private Potion_JSON_Reader.Potion _potionReference;

        private void Awake()
        {
            _currentIngredients = new List<int>();
            _currentState = PotionState.Empty;
        }

        public void SetPotionId(int id)
        {
            _potionId = id;
        }
        
        public void AddIngredient(int id)
        {
            Debug.Log("Added ingredient id: " + id);
            _currentIngredients.Add(id);
        }
        
        public void GrindIngredients()
        {
            _allPotionList = GameObject.Find("Potion_Loader").GetComponent<Potion_JSON_Reader>().GetPotionList();
            // Debug.Log("Ingredient Count: " + _currentIngredients.Count);
            int neededIngredients = 0;
            
            foreach (var potionEntry in _allPotionList)
            {
                neededIngredients = 0;
                Potion_JSON_Reader.Potion potion = potionEntry.Value;
                // Debug.Log("Checking " + potion.name);
                
                foreach (var ingredient in potion.ingredients.ingredient)
                {
                    neededIngredients += ingredient.quantity;
                }

                if (_currentIngredients.Count != neededIngredients)
                {
                    continue; 
                }

                bool isMatch = true;
                
                foreach (var ingredient in potion.ingredients.ingredient)
                {
                    int ingredientCount = _currentIngredients.Count(x => x == ingredient.id);
                    if (ingredientCount != ingredient.quantity)
                    {
                        isMatch = false;
                        break;
                    }
                }

                if (isMatch) 
                {
                    _potionReference = potion; 
                    // Debug.Log("Potion found: " + _potionReference.name);
                    if (_currentState != PotionState.Empty)
                    {
                        if (_currentState == PotionState.Ground)
                            Debug.Log("Ingredients have already been ground");
                        else if (_currentState == PotionState.Brewed)
                            Debug.Log("Potion has already been brewed");
                        else
                        {
                            Debug.Log("Incorrect - unknown error");
                        }
                        _currentState = PotionState.Failed;
                        HandleFailure();
                    }
                    else
                    {
                        Debug.Log("Grinding Ingredients");
                        _potionId = potion.id;
                        Debug.Log("Added potion id: " + _potionId);
                        _currentState = PotionState.Ground;
                    }
                    return;
                }
            }
            
            Debug.Log("No matching potion found for the ingredients.");
            _currentState = PotionState.Failed;
            HandleFailure();
        }

        public void BrewPotion()
        {
            if (_currentState != PotionState.Ground)
            {
                if (_currentState == PotionState.Brewed)
                    Debug.Log("Potion has already been brewed");
                else
                    Debug.Log("Potion has not been brewed yet");
                _currentState = PotionState.Failed;
                HandleFailure();
            }
            else
            {
                Debug.Log("Brewing potion");
                _currentState = PotionState.Brewed;
            }
        }

        public void HandleFailure()
        {
            Debug.Log("Potion discarded");
            Destroy(gameObject);
        }

        public void Update()
        {
            //Debug.Log("Update");
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GrindIngredients();
            }
            
            if (Input.GetKeyDown(KeyCode.W))
            {
                BrewPotion();
            }
        }
    }
}