using System.Collections.Generic;
using UnityEngine;

namespace Jenna
{
    [System.Serializable]
    public class IngredientMaterialPair
    {
        public int id;
        public Texture texture;
    }

    public class IngredientMaterials : MonoBehaviour
    {
        [SerializeField] private List<IngredientMaterialPair> _ingredientMatsList;

        private Dictionary<int, Texture> _ingredientMats;

        private void Awake()
        {
            _ingredientMats = new Dictionary<int, Texture>();
            foreach (var pair in _ingredientMatsList)
            {
                _ingredientMats.Add(pair.id, pair.texture);
            }
        }
        
        public Dictionary<int, Texture> GetIngredientTextures()
        {
            return _ingredientMats;
        }
    }
}