using UnityEngine;
using UnityEngine.EventSystems;

namespace Jenna
{
    public class CameraManager : MonoBehaviour
    {
        public Camera cam1;
        public Camera cam2;
        private GameObject orderOverlay = null;
        private GameObject recipeOverlay = null;

        void Start() {
            cam1.enabled = true;
            cam1.GetComponent<PhysicsRaycaster>().enabled = true;
            cam2.enabled = false;
            cam2.GetComponent<PhysicsRaycaster>().enabled = false;
            orderOverlay = GameObject.Find("Canvas/Order_Overlay");
            if (orderOverlay != null)
                orderOverlay.SetActive(true);
            else
            {
                Debug.Log("order overlay not found");
            }
            
            recipeOverlay = GameObject.Find("Canvas/Recipe_Overlay");
            if (recipeOverlay != null)
                recipeOverlay.SetActive(false);
            else
            {
                Debug.Log("recipe overlay not found");
            }
        }

        void Update() {

            if (Input.GetKeyDown(KeyCode.C)) {
                cam1.enabled = !cam1.enabled;
                cam2.enabled = !cam2.enabled;
            }
        }

        public void SwitchCameras()
        {
            cam1.enabled = !cam1.enabled;
            cam1.GetComponent<PhysicsRaycaster>().enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
            cam2.GetComponent<PhysicsRaycaster>().enabled = !cam2.enabled;

            if (cam2.enabled)
            {
                orderOverlay.SetActive(false);
                recipeOverlay.SetActive(true);
                GameManager.Instance.RecipeInterfaceOpen = true;
                GameManager.Instance.BrewingInterfaceOpen = false;
            }
            else
            {
                orderOverlay.SetActive(true);
                recipeOverlay.SetActive(false);
                GameManager.Instance.RecipeInterfaceOpen = false;
                GameManager.Instance.BrewingInterfaceOpen = true;
            }
        }

        public void MainCamera()
        {
            cam1.enabled = true;
            cam1.GetComponent<PhysicsRaycaster>().enabled = true;
            cam2.enabled = false;
            cam2.GetComponent<PhysicsRaycaster>().enabled = false;
            orderOverlay.SetActive(true);
            recipeOverlay.SetActive(false);
            GameManager.Instance.RecipeInterfaceOpen = false;
        }
    }
}