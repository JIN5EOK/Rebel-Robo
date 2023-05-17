using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// By Jinseok Bae
public class Player : Entity, IMoveable
{
    [SerializeField]
    protected PlayerStatus status;

    private int energy;
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

    public void Move(Vector3 _vec)
    {
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
}