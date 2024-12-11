using UnityEngine;

namespace Jenna
{
    public class InventoryToggle : MonoBehaviour
    {
        [SerializeField] private GameObject layerOne;
        [SerializeField] private GameObject layerTwo;

        void Start()
        {
            layerOne.SetActive(true);
            layerTwo.SetActive(false);
        }

        public void ToggleLayers()
        {
            layerOne.SetActive(!layerOne.activeSelf);
            layerTwo.SetActive(!layerTwo.activeSelf);

        }
    }
}