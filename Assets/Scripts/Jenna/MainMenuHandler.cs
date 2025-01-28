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
        
        public void StartGame()
        {
            SceneManager.LoadScene("LVL_Brew");
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