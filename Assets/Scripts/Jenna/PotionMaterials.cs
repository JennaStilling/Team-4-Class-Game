using System.Collections.Generic;
using UnityEngine;

namespace Jenna
{
    [System.Serializable]
    public class PotionMaterialPair
    {
        public int id;
        public Texture texture;
    }

    public class PotionMaterials : MonoBehaviour
    {
        [SerializeField] private List<PotionMaterialPair> _potionMatsList;

        private Dictionary<int, Texture> _potionMats;

        private void Awake()
        {
            // Convert List to Dictionary on start
            _potionMats = new Dictionary<int, Texture>();
            foreach (var pair in _potionMatsList)
            {
                _potionMats.Add(pair.id, pair.texture);
            }
        }
        
        public Dictionary<int, Texture> GetPotionMaterials()
        {
            return _potionMats;
        }
    }
}