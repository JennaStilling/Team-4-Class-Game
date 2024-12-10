using System;
using System.Collections;
using System.Collections.Generic;
using Data_Reading;
using UnityEngine;
using System.Linq;
using UnityEngine.UI; // Add this at the top of your file

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

        public int GetPotionId()
        {
            return _potionId;
        }

        public void AddIngredient(int id)
        {
            Debug.Log("Added ingredient id: " + id);
            _currentIngredients.Add(id);
        }

        public void GrindIngredients()
        {
            _allPotionList = GameObject.Find("Potion_Loader").GetComponent<Potion_JSON_Reader>().GetPotionList();
            int neededIngredients = 0;

            foreach (var potionEntry in _allPotionList)
            {
                neededIngredients = 0;
                Potion_JSON_Reader.Potion potion = potionEntry.Value;

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
                        _potionId = potion.id;

                        Debug.Log("Grinding ingredients for " + _potionReference.grind_time + " seconds");
                        StartCoroutine(GrindTimeCoroutine(potion.grind_time));
                    }

                    return;
                }
            }

            Debug.Log("No matching potion found for the ingredients.");
            _currentState = PotionState.Failed;
            HandleFailure();
        }
        
        private IEnumerator GrindTimeCoroutine(float grindTime)
        {
            yield return new WaitForSeconds(grindTime);
            
            _currentState = PotionState.Ground;
            Debug.Log("Grinding complete.");
            Debug.Log("Added potion id: " + _potionId);
        }

        public void BrewPotion()
        {
            if (_currentState != PotionState.Ground)
            {
                if (_currentState == PotionState.Brewed)
                    Debug.Log("Potion has already been brewed");
                else
                    Debug.Log("Potion has not been ground yet");
                _currentState = PotionState.Failed;
                HandleFailure();
            }
            else
            {
                Debug.Log("Brewing potion for " + _potionReference.cook_time + " seconds");
                StartCoroutine(BrewTimeCoroutine(_potionReference.cook_time));
            }
        }

        // Coroutine for brew time
        private IEnumerator BrewTimeCoroutine(float cookTime)
        {
            yield return new WaitForSeconds(cookTime); 
            
            Debug.Log("Potion brewed.");
            _currentState = PotionState.Brewed;

            Texture potionTexture = GameObject.Find("Potion_Loader").GetComponent<PotionMaterials>().GetPotionMaterials()[_potionId];
            if (potionTexture is Texture2D texture2D)
            {
                Rect rect = new Rect(0, 0, texture2D.width, texture2D.height);
                Sprite potionSprite = Sprite.Create(texture2D, rect, new Vector2(0.5f, 0.5f));
                GetComponent<Image>().sprite = potionSprite;
            }
            else // found error message
            {
                Debug.LogError("Failed to convert potion material texture to Texture2D.");
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
