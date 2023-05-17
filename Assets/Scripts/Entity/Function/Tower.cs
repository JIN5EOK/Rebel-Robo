using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
// By Jinseok Bae
/// <summary>
/// 타워
/// </summary>
public abstract class Tower : Entity, IDemolitionable
{
    [SerializeField]
    protected TowerStatus status;
    
    protected abstract void OnRange(Entity _target);
    protected abstract void OutRange(Entity _target);

    protected abstract void Attack(Enemy _target);

    public void Demolition(ref int _energy)
    {
        
        // 가격의 절반만큼 돌려받고 파괴
        _energy += status.RefundCost;
    }
}
