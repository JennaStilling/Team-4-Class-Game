using Jenna;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Clicked mouse");
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("Clicked on: " + hit.collider.gameObject.name);
                ClickToOrder clickable = hit.collider.GetComponent<ClickToOrder>();
                if (clickable != null)
                {
                    clickable.PerformAction();
                }

                // UI_ClickHandler ui_clickable = hit.collider.GetComponent<UI_ClickHandler>();
                // if (ui_clickable != null)
                // {
                //     Debug.Log("Not null");
                //     ui_clickable.PerformAction(hit);
                // }
                // else
                // {
                //     Debug.Log("ui thing null");
                // }
            }
        }
    }
}