using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
// By Jinseok Bae
public class Player : Entity, IMoveable
{
    [SerializeField]
    protected PlayerStatus status;

    private int energy;

    Vector3 moveDir = new Vector3();
    private int Energy
    {
        get => energy;
        set => energy = Mathf.Clamp(value, 0, status.MaxEnergy);
    }

    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move(moveDir);
    }

    public void Move(Vector3 _vec)
    {
        if (_vec == Vector3.zero)
            return;
        
        rigid.MovePosition(transform.position + _vec * status.MoveSpd * Time.deltaTime);
    }

    public void UseSkill()
    {
        Debug.Log("스킬 사용");   
    }
    
    public void CreateTower()
    {
        Debug.Log("타워 빌드");
    }

    public void DemolitionEntity(IDemolitionable entity)
    {
        int tempEnergy = Energy;
        entity.Demolition(ref tempEnergy);
        Energy = tempEnergy;
    }

    private void OnMove(InputValue _value)
    {
        Vector2 dir = _value.Get<Vector2>();
        
        moveDir = new Vector3(dir.x, 0, dir.y);
        moveDir = moveDir.normalized;
    }
}