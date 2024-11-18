using UnityEngine;

namespace Player_Potion_Making
{
    public class PotionMakingManager : MonoBehaviour
    {
        public static PotionMakingManager Instance;

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
    }
}