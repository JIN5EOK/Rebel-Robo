using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

// By Jinseok Bae

/// <summary>
/// 적 엔터티 스크립트
/// </summary>
public class Enemy : Entity, IMoveable, IDamageable
{
    [SerializeField]
    protected EnemyStatus status;

    private NavMeshAgent nav;
    private int Hp { get; set; }

    private Rigidbody rigid;

    //해당 부분 김하늘 작성  06-18
    private Material originalMaterial; //원본 메테리얼
    private Renderer materialRenderer; //랜더러

    [SerializeField]
    private Material damagedMaterial; //데미지 입을 당시 할당된 메테리얼
    

    public void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
        Hp = status.MaxHp;
        nav.speed = status.MoveSpd;

        //김하늘 작성
        materialRenderer = GetComponent<Renderer>();
        originalMaterial = materialRenderer.material;

    }

    void OnEnable()
    {
        if (PlayerHQ.instance != null)
        {
            SetNavDest(PlayerHQ.instance.transform.position);
        }
    }
    
    public void SetNavDest(Vector3 _vec)
    {
        nav.SetDestination(_vec);
    }
    public void SetStopNav()
    {
        nav.Stop();
    }
    public void Move(Vector3 _vec)
    {
        rigid.MovePosition(transform.position + _vec * status.MoveSpd * Time.deltaTime);
    }

    public void Damaged(int _dmg)
    {
        Debug.Log(name +" "+ _dmg+ "의 데미지!");
        Hp -= _dmg;

        // 해당 부분 김하늘 작성
        StartCoroutine(FlashMaterial()); //반짝이는 코루틴
        
        if (Hp <= 0)
        {
            Destroyed();
        }
    }

    //해당 부분 김하늘 작성
    private IEnumerator FlashMaterial()
    {
        materialRenderer.material = damagedMaterial;
        yield return new WaitForSeconds(0.1f);
        materialRenderer.material = originalMaterial;
    }

    public override void Destroyed()
    {
        ItemFactory.Instance.Spawn(Items.Energy, transform.position, Quaternion.identity);
        base.Destroyed();
    }
    private void ArriveDest(PlayerHQ _hq)
    {
        // 기지에 데미지 준 다음 파괴됨
        _hq.Damaged(status.Dmg);
        Destroyed();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        PlayerHQ hq;
        // 기지와 충돌하였음.
        if (other.gameObject.TryGetComponent(out hq) == true)
        {
            ArriveDest(hq);
        }
    }
}
