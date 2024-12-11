using UnityEngine;
using UnityEngine.SceneManagement;

namespace Jenna {
    public class GameManager : MonoBehaviour
    {
        public bool BrewingInterfaceOpen { get; set; } = false;
        public bool RecipeInterfaceOpen { get; set; } = false;
        
        public bool GamePaused { get; set; } = false;
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

        private int _potionsRuined;
        public int PotionsRuined
        {
            get { return _potionsRuined; }
            set
            {
                _potionsRuined = value;
                if (_potionsRuined >= 5)
                    HandleGameOver();
            }
        }
        private int _ordersRuined;

        public int OrdersRuined
        {
            get { return _ordersRuined; }
            set
            {
                _ordersRuined = value;
                if (_ordersRuined >= 5)
                    HandleGameOver();
            }
        }

        public int PotionsMade { get; set; } = 0;
        public int OrdersComplete { get; set; } = 0;

        public int CoinCount { get; set; } = 100;

        void Update()
        {
            
        }

        private void HandleGameOver()
        {
            Debug.Log("Game over!");
            _potionsRuined = 0;
            _ordersRuined = 0;
            SceneManager.LoadScene("LVL_StartMenu");
        }
    }
}