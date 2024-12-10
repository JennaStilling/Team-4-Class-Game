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

        public int PotionsRuined { get; set; } = 0;
        public int OrdersRuined { get; set; } = 0;

        public int PotionsMade { get; set; } = 0;
        public int OrdersComplete { get; set; } = 0;

        public int CoinCount { get; set; } = 100;

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