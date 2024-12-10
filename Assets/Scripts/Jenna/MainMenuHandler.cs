using UnityEngine;
using UnityEngine.SceneManagement;

namespace Jenna
{
    public class MainMenuHandler : MonoBehaviour
    {
        public void StartTutorial()
        {
            Debug.Log("Not implemented");
        }
        
        public void StartStoryMode()
        {
            Debug.Log("Not implemented");
        }
        
        public void StartGame()
        {
            //Time.timeScale = 1f;
            SceneManager.LoadScene("LVL_Brew");
            //isPaused = false;
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