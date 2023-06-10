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
    [SerializeField]private Sfxs hitSound;
    public static PlayerHQ instance;
    [SerializeField]
    private HQStatus status;

    private int hp;
    public Action<int> OnHpChange;
    public Action OnHQDestroyed; // 매개변수, 반환값 없는 함수나 람다함수를 += 연산자로 추가해서 사용하시면 됩니다. 제거하고 싶을땐 -=
    private int Hp
    {
        get => hp;
        set
        {
            hp = value;
            if(OnHpChange != null)
                OnHpChange.Invoke(value);
        }
    }

    private void Start()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);            
        }
        instance = this;

        Hp = status.MaxHp;

        OnHQDestroyed += () => { Debug.Log("게임 오버"); };
    }

    public void Damaged(int _dmg)
    {
        AudioManager.Instance.PlaySfx(hitSound, this.transform);
        Hp -= _dmg;
        
        if (Hp <= 0 && OnHQDestroyed != null)
        {
            OnHQDestroyed.Invoke();
        }
    }
}
