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
        private Potion_JSON_Reader.Potion _potionReference;

        private void Awake()
        {
            // _potionReference = GameObject.Find("Potion_Loader").GetComponent<Potion_JSON_Reader>().GetPotionById(_potionId);
            _currentIngredients = new List<int>();
            _currentState = PotionState.Empty;
        }

        public void SetPotionId(int id)
        {
            _potionId = id;
        }

        // Needed?
        public UI_Potion(int potionId)
        {
            _currentIngredients = new List<int>();
            _potionId = potionId;
            _currentState = PotionState.Empty;
        }
        
        public void AddIngredient(int id)
        {
            Debug.Log("Added ingredient id: " + id);
            _currentIngredients.Add(id);
        }
        
        public void GrindIngredients()
        {
            _potionReference = GameObject.Find("Potion_Loader").GetComponent<Potion_JSON_Reader>().GetPotionById(_potionId);
            Debug.Log(_potionReference.name);
    
            // Check if the number of ingredients match
            if (_currentIngredients.Count != _potionReference.ingredients.ingredient.Count)
            {
                Debug.Log("Ingredient count mismatch");
                _currentState = PotionState.Failed;
                HandleFailure();
                return;
            }
    
            // Compare each ingredient by both id and quantity
            foreach (var ingredient in _potionReference.ingredients.ingredient)
            {
                if (_currentIngredients.Count(x => x == ingredient.id) != ingredient.quantity)
                {
                    Debug.Log("Ingredients mismatch for: " + ingredient.ingredient_name);
                    _currentState = PotionState.Failed;
                    HandleFailure();
                    return;
                }
            }
            
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
                _currentState = PotionState.Ground;
            }
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