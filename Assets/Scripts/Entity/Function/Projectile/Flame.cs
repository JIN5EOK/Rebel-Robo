using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// By Jinseok Bae
/// <summary>
/// 화염방사 타워의 ㄴ화염
/// </summary>
public class Flame : Projectile
{
    private float deadTime = 1.0f;

    private ParticleSystem particle;


    private void FixedUpdate()
    {
        Timer();
    }
    // 콜라이더에 닿는다면 데미지 판정 추가하기

    void Timer()
    {
        deadTime -= Time.deltaTime;
        
        if(deadTime <= 0.0f)
            Destroyed();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.layer != LayerMask.NameToLayer("Enemy"))
            return;
        
        Enemy enemy;
        if (other.TryGetComponent<Enemy>(out enemy))
        {
            enemy.Damaged(dmg);
        }
    }
}
