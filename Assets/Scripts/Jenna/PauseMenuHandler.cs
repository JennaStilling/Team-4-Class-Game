using UnityEngine;
using UnityEngine.SceneManagement;

namespace Jenna
{
    public class PauseMenuHandler : MonoBehaviour
    {
        private bool _isPaused = false;
        public void PauseGame()
        {
            Debug.Log("Paused");
            Time.timeScale = 0f;
            GameObject.Find("Canvas/Order_Overlay/Buttons").SetActive(false);
            GameObject.Find("Canvas/Order_Overlay/Orders").SetActive(false);
            _isPaused = true;
        }
        
        public void QuitToMenu()
        {
            Time.timeScale = 1f;
            _isPaused = false;
            SceneManager.LoadScene("LVL_StartMenu");
        }
        
        public void ResumeGame()
        {
            Time.timeScale = 1f;
            GameObject pauseMenu = GameObject.Find("Canvas/Order_Overlay/Pause_Menu");
            pauseMenu.SetActive(false);
            GameObject.Find("Canvas/Order_Overlay/Buttons").SetActive(true);
            GameObject.Find("Canvas/Order_Overlay/Orders").SetActive(true);
            _isPaused = false;
            GameManager.Instance.GamePaused = _isPaused;
        }

        public void QuitGame()
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        }
    }
}