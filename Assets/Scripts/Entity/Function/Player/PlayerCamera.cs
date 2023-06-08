using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerCamera : MonoBehaviour
{
    // Baejinseok
    private Transform cameraTrans;
    private Vector3 targetPos;
    private Vector3 lastPos;
    private Camera cam;

    private Vector2 touchStartPos;
    private bool isTouching;

    private float rotationX;


    public void RotationVertical(Vector3 _vec)
    {
        rotationX += _vec.y;
        rotationX = Mathf.Clamp(rotationX,  -20, 60) ;
        transform.localRotation = Quaternion.Euler(new Vector3(rotationX, this.transform.localRotation.y, this.transform.localRotation.z));
    }
    
    private void OnEnable()
    {
        rotationX = 0.0f;
        cam = Camera.main;
        cameraTrans = cam.transform;
        cameraTrans.transform.position = this.transform.position;
        targetPos = this.transform.position;
        lastPos = this.transform.position;
    }

    private void OnDisable()
    {
        cameraTrans = null;
    }
    
    private void LateUpdate()
    {
        targetPos = this.transform.position - transform.TransformDirection(Vector3.forward) * 5;
        
        cameraTrans.transform.position = Vector3.Lerp(lastPos, targetPos, Time.deltaTime * 15);
        Vector3 dir = this.transform.position - cameraTrans.position;
        cameraTrans.rotation = Quaternion.Lerp(cameraTrans.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 15);
        
        lastPos = cameraTrans.position;
    }
}
