using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraManager : MonoBehaviour
{
    private float touchStartX;
    private float touchStartY;
    // Start is called before the first frame update
    
    void Update()
    {
        
        if (Input.touchCount > 0)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                return;
            }
                

            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began) 
                { 
                    touchStartX = touch.position.x;
                    touchStartY = touch.position.y;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    float deltaX = touch.position.x - touchStartX;
                    float deltaY = touch.position.y - touchStartY;

                    float rotationSpeed = 0.01f; 

                    transform.Rotate(Vector3.up, deltaX * rotationSpeed);
                    transform.Rotate(Vector3.right, -deltaY * rotationSpeed);
                }
            }
        }
        /*
        if (Input.GetMouseButtonDown(0))
        {
            touchStartX = Input.mousePosition.x;
            touchStartY= Input.mousePosition.y;
        }
        else if (Input.GetMouseButton(0))
        {
            float deltaX = Input.mousePosition.x - touchStartX;
            float deltaY = Input.mousePosition.y - touchStartY;

            float rotationSpeed = 0.0001f; // 조정 가능한 회전 속도
            transform.Rotate(Vector3.up, deltaX * rotationSpeed);
            transform.Rotate(Vector3.right, -deltaY * rotationSpeed);
        }
        */
    }
}
