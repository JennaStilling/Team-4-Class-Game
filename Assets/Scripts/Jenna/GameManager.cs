using UnityEngine;

namespace Jenna {
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        

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

        public int CurrentDay { get; private set; }
        
        public int PotionsRuined { get; set; }
        public int OrdersRuined { get; set; }
        
        public int PotionsMade { get; set; }
        public int OrdersComplete { get; set; }

        void Update()
        {
            if (PotionsRuined >= 5 || OrdersRuined >= 3)
            {
                HandleGameOver();
            }
        }

        private void HandleGameOver()
        {
            Debug.Log("Game over!");
        }
    }
}