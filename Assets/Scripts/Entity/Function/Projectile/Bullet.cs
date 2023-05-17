using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// By Jinseok Bae
/// <summary>
/// 타워의 총알
/// </summary>
public class Bullet : Projectile
{
    private void FixedUpdate()
    {
        if (target == null && isLaunch == false)
        {
            return;
        }
        if (target == null && isLaunch == true)
        {
            Destroyed();
            return;
        }
        this.transform.position = Vector3.MoveTowards(transform.position,target.transform.position, 20.0f * Time.deltaTime);
    }

    protected virtual void OnHit()
    {
        target.Damaged(dmg);
        Destroyed();
    }
    
    protected void OnTriggerEnter(Collider other)
    {
        if (target == null && isLaunch == false)
        {
            return;
        }

        if (other.transform.gameObject == target.transform.gameObject)
        {
            OnHit();
        }
    }
}
