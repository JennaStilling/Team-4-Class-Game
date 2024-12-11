using UnityEngine;
using UnityEngine.EventSystems;

namespace Jenna
{
    public class CameraManager : MonoBehaviour
    {
        public Camera cam1;
        public Camera cam2;

        void Start() {
            cam1.enabled = true;
            cam1.GetComponent<PhysicsRaycaster>().enabled = true;
            cam2.enabled = false;
            cam2.GetComponent<PhysicsRaycaster>().enabled = false;
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
                GameManager.Instance.RecipeInterfaceOpen = true;
                GameManager.Instance.BrewingInterfaceOpen = false;
            }
        }

        public void MainCamera()
        {
            cam1.enabled = true;
            cam1.GetComponent<PhysicsRaycaster>().enabled = true;
            cam2.enabled = false;
            cam2.GetComponent<PhysicsRaycaster>().enabled = false;
            GameManager.Instance.RecipeInterfaceOpen = false;
        }
    }
}