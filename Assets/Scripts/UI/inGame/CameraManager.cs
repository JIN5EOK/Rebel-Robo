using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private float touchStartX;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount > 0)
        {
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began) 
                { 
                    touchStartX = touch.position.x; 
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    float deltaX = touch.position.x - touchStartX;
                    float rotationSpeed = 0.0001f; 
                    transform.Rotate(Vector3.up, deltaX * rotationSpeed);
                }
            }
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            touchStartX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            float deltaX = Input.mousePosition.x - touchStartX;
            float rotationSpeed = 0.0001f; // 조정 가능한 회전 속도
            transform.Rotate(Vector3.up, deltaX * rotationSpeed);
        }
    }
}
