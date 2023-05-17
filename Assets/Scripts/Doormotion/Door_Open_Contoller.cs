using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open_Contoller : MonoBehaviour
{
    public Animator left_Ani, right_Ani;

    void OnTriggerEnter(Collider other)
    {
        left_Ani.SetTrigger("LeftDoorOpen");
        right_Ani.SetTrigger("RightDoorOpen");

    }

    void OnTriggerExit(Collider other)
    {
        left_Ani.SetTrigger("LeftDoorClose");
        right_Ani.SetTrigger("RightDoorClose");
        
    }
}
