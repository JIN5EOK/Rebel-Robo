using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

// Baejinseok
public class Pet : MonoBehaviour
{
    [SerializeField]
    private Transform petTrans;
    [SerializeField]
    private Vector3 lastPos;

    private void Start()
    {
        lastPos = this.transform.position;
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(lastPos, petTrans.transform.position, Time.deltaTime * 5);
        lastPos = this.transform.position;
    }
}
