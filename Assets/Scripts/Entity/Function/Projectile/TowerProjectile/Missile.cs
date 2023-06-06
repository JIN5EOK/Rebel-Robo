using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// By Jinseok Bae
/// <summary>
/// 타워의 총알
/// </summary>
public class Missile : Bullet
{
    protected void OnTriggerEnter(Collider other)
    {
        if (target == null && isLaunch == false)
        {
            return;
        }
        if(other.gameObject != target.gameObject)
            return;
        
        Collider[] enemys = Physics.OverlapSphere(this.transform.position, 3.0f, LayerMask.GetMask("Enemy"));
        Enemy enemy;
        foreach (Collider c in enemys)
        {
            if(c.TryGetComponent<Enemy>(out enemy) && target != enemy)
            {
                enemy.Damaged(dmg / 2);
            }
        }
        
        base.OnTriggerEnter(other);
    }
}
