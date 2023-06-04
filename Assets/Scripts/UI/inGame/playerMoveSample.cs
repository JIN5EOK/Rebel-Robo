using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoveSample : MonoBehaviour
{
    public float speed;
    private Joystick joystick;
    // Start is called before the first frame update
    void Awake()
    {
        joystick = GameObject.FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            MoveControl();
        }
    }

    private void MoveControl()
    {
        Vector3 verticalMove = Vector3.forward * speed * Time.deltaTime * joystick.Vertical;
        Vector3 horizontalMove = Vector3.right * speed * Time.deltaTime * joystick.Horizontal;
        transform.position += verticalMove;
        transform.position += horizontalMove;
    }
}
