using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// By Jinseok Bae
/// <summary>
/// 아군기지 클래스
/// </summary>
public class PlayerHQ : Entity, IDamageable
{
    
    public static PlayerHQ instance;
    [SerializeField]
    private HQStatus status;
    private int Hp { get; set; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);            
        }
        instance = this;

        Hp = status.MaxHp;
    }

    public override void Destroyed()
    {
        Debug.Log("게임 오버...");
        base.Destroyed();
    }

    public void Damaged(int _dmg)
    {
        Hp -= _dmg;
        
        if (Hp <= 0)
        {
            Destroyed();
        }
    }
}
