using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// By Jinseok Bae
/// <summary>
/// 미사일형 투사체
/// </summary>
public abstract class Projectile : Entity
{
    protected Enemy target;
    protected int dmg;
    protected bool isLaunch;
    private void Start()
    {
        if (target != null)
        {
            Vector3 targetPos;
            targetPos = new Vector3(target.transform.position.x,this.transform.position.y,target.transform.position.z);
            transform.LookAt(targetPos);
        }
    }
    public void Launch(Enemy _target, int _dmg)
    {
        target = _target;
        dmg = _dmg;
        isLaunch = true;
    }
}