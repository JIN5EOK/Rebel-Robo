using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMoveSample : MonoBehaviour
{
    

    PlayerAction action;
    InputAction moveAction;

    public float moveSpeed;

    private void Awake()
    {
        action = new PlayerAction();
        moveAction = action.Player.Move;
    }

    private void OnEnable()
    {
        moveAction.Enable();
        
    }

    private void FixedUpdate()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);
        MOVE(moveDirection.x, moveDirection.y, moveDirection.z);
    }

    private void OnDisable()
    {
        moveAction.Disable();
        
    }

    

    void MOVE(float _x, float _y, float _z)
    {
        moveSpeed = 0.1f;
        this.transform.position = new Vector3(this.transform.position.x + (_x * moveSpeed), 0, this.transform.position.z + (_z * moveSpeed));
    }
}
