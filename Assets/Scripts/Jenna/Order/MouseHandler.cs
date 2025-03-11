using Jenna;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private float _touchStartTime;
    private const float TOUCH_THRESHOLD = 0.2f;
    private Vector2 _touchStartPosition;
    private const float MAX_TAP_MOVEMENT = 20f;

    void Update()
    {
        // Handle mouse input for editor/desktop
        #if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick(Input.mousePosition);
        }
        #endif

        // Handle touch input for mobile
        #if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _touchStartTime = Time.time;
                    _touchStartPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    float touchDuration = Time.time - _touchStartTime;
                    float touchMovement = Vector2.Distance(_touchStartPosition, touch.position);
                    
                    if (touchDuration < TOUCH_THRESHOLD && touchMovement < MAX_TAP_MOVEMENT)
                    {
                        HandleClick(touch.position);
                    }
                    break;
            }
        }
        #endif
    }

    private void HandleClick(Vector2 screenPosition)
    {
        Ray ray = _camera.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            ClickToOrder clickable = hit.collider.GetComponent<ClickToOrder>();
            if (clickable != null)
            {
                clickable.PerformAction();
            }
        }
    }
}