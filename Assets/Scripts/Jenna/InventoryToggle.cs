using UnityEngine;
using UnityEngine.EventSystems;

namespace Jenna
{
    public class InventoryToggle : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private GameObject layerOne;
        [SerializeField] private GameObject layerTwo;
        [SerializeField] private float swipeThreshold = 50f;
        [SerializeField] private float animationDuration = 0.3f;
        
        private Vector2 touchStart;
        private bool isAnimating = false;
        private CanvasGroup layerOneGroup;
        private CanvasGroup layerTwoGroup;

        void Start()
        {
            layerOne.SetActive(true);
            layerTwo.SetActive(false);

            // Add CanvasGroup components if they don't exist
            layerOneGroup = layerOne.GetComponent<CanvasGroup>();
            if (layerOneGroup == null)
                layerOneGroup = layerOne.AddComponent<CanvasGroup>();

            layerTwoGroup = layerTwo.GetComponent<CanvasGroup>();
            if (layerTwoGroup == null)
                layerTwoGroup = layerTwo.AddComponent<CanvasGroup>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            touchStart = eventData.position;
            StartCoroutine(HandleSwipe(eventData));
        }

        private System.Collections.IEnumerator HandleSwipe(PointerEventData eventData)
        {
            while (!Input.GetMouseButtonUp(0)) // Works for both mouse and touch
            {
                yield return null;
            }

            float swipeDistance = eventData.position.x - touchStart.x;

            if (Mathf.Abs(swipeDistance) > swipeThreshold)
            {
                if ((swipeDistance > 0 && !layerOne.activeSelf) || 
                    (swipeDistance < 0 && layerOne.activeSelf))
                {
                    ToggleLayersWithAnimation();
                }
            }
        }

        public void ToggleLayers()
        {
            if (!isAnimating)
            {
                ToggleLayersWithAnimation();
            }
        }

        private void ToggleLayersWithAnimation()
        {
            if (isAnimating) return;
            isAnimating = true;

            // Ensure both layers are active for animation
            layerOne.SetActive(true);
            layerTwo.SetActive(true);

            StartCoroutine(AnimateLayers(layerOne.activeSelf));
        }

        private System.Collections.IEnumerator AnimateLayers(bool isLayerOneActive)
        {
            float elapsed = 0f;
            CanvasGroup fadeOut = isLayerOneActive ? layerOneGroup : layerTwoGroup;
            CanvasGroup fadeIn = isLayerOneActive ? layerTwoGroup : layerOneGroup;

            fadeIn.alpha = 0f;
            fadeOut.alpha = 1f;

            while (elapsed < animationDuration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / animationDuration;

                fadeOut.alpha = Mathf.Lerp(1f, 0f, t);
                fadeIn.alpha = Mathf.Lerp(0f, 1f, t);

                yield return null;
            }

            // Ensure final states
            fadeOut.alpha = 0f;
            fadeIn.alpha = 1f;

            // Deactivate the faded out layer
            fadeOut.gameObject.SetActive(false);
            fadeIn.gameObject.SetActive(true);

            isAnimating = false;

            // Play haptic feedback on mobile
            #if UNITY_IOS || UNITY_ANDROID
            if (SystemInfo.supportsVibration)
            {
                Handheld.Vibrate();
            }
            #endif
        }
    }
}