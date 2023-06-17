using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

// By Jinseok Bae
public class Player : Entity, IMoveable
{
    [SerializeField]
    public PlayerStatus status;
    public static Player Instance { get; private set; }
    public Animator animator;
    private int energy;
    public int Energy
    {
        get => energy;
        set
        {
            energy = Mathf.Clamp(value, 0, status.MaxEnergy);
            if(EnergyChangeAction != null)
            EnergyChangeAction.Invoke(energy);
        }
    }
    private Vector3 moveDir = new Vector3();
    private Vector3 rotDir = new Vector3();
    private Rigidbody rigid;

    
    public Action<int> EnergyChangeAction;

    [SerializeField]
    private PlayerCamera playerCamera;
    private PlayerTowerBuildHandler towerBuildHandler;
    private PlayerSkillHandler skillHandler;

    [SerializeField]private Pet pet;

    private CoolTime atkCoolTime;

    [SerializeField] private Sfxs attackSound;
    public int AttackCount = 0;
    private void Start()
    { 

        skillHandler = GetComponent<PlayerSkillHandler>();
        towerBuildHandler = GetComponent<PlayerTowerBuildHandler>();
        rigid = GetComponent<Rigidbody>();
        atkCoolTime = new CoolTime(status.AtkSpd);
    }

    private void OnEnable()
    {
        base.OnEnable();
        StartCoroutine("EnergyRecovery");
    }

    private void OnDisable()
    {
        base.OnDisable();
        
    }

    private void FixedUpdate()
    {
        Move(moveDir);
        Attack();
        RotationHorizontal(rotDir);
        playerCamera.RotationVertical(rotDir);
        SetCoolTime();
    }

    public void SetCoolTime()
    {
        atkCoolTime.CurCoolTime -= Time.deltaTime;
    }
    
    private void RotationHorizontal(Vector3 _dir)
    {
        transform.Rotate(Vector3.up, _dir.x * -1);
    }
    
    public void Move(Vector3 _vec)
    {
        animator.SetFloat("moveSpeed", Vector3.Magnitude(moveDir));
        
        if (_vec == Vector3.zero)
            return;

        Vector3 dir = transform.TransformDirection(_vec);
        rigid.MovePosition(transform.position + dir * status.MoveSpd * Time.deltaTime);
    }

    private void UseSkill(Skills _skill)
    {
        skillHandler.Execute(_skill);   
    }
    
    public void CreateTower(Towers _tower)
    {
        towerBuildHandler.BuildTower(_tower);
    }

    public void RemoveTower()
    {
        towerBuildHandler.RemoveTower();
    }
    
    private void DemolitionEntity(IDemolitionable entity)
    {
        int tempEnergy = Energy;
        entity.Demolition(ref tempEnergy);
        Energy = tempEnergy;
    }

    private void OnMove(InputValue _value)
    {
        Vector2 dir = _value.Get<Vector2>();
        
        moveDir = new Vector3(dir.x, 0, dir.y);
    }

    private void Attack()
    {
        if (atkCoolTime.IsComplete == false)
        {
            return;
        }
        
        Vector3 targetPos;
        RaycastHit hit;
        
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        Enemy enemy;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Enemy")))
        {
            if(hit.transform.TryGetComponent(out enemy))
            {
                AttackCount++;
                targetPos = hit.point;
                TowerProjectile b = TowerProjectileFactory.Instance.Spawn(TowerProjectiles.Bullet, pet.transform.position, Quaternion.identity);
                b.Launch(hit.transform.gameObject.GetComponent<Enemy>(), (int)status.Dmg);
                AudioManager.Instance.PlaySfx(attackSound, pet.transform);
                atkCoolTime.Reset();
            }
        }
    }
    
    
    IEnumerator EnergyRecovery()
    {
        while (true)
        {
            Energy += status.EnergyRecoveryPerSecond;
            yield return new WaitForSeconds(1.0f);
        }
    }
    
    private void OnRotation(InputValue _value)
    {
        Vector2 dir = _value.Get<Vector2>();
        rotDir = new Vector3(dir.x, dir.y, 0);
        rotDir *= -2;
    }
    private void OnBuildTower1(InputValue _value)
    {
        CreateTower(Towers.MachinegunTower);
    }
    private void OnBuildTower2(InputValue _value)
    {
        CreateTower(Towers.FlameTower);
    }
    private void OnBuildTower3(InputValue _value)
    {
        CreateTower(Towers.MissileTower);
    }
    private void OnSkill1(InputValue _value)
    {
        UseSkill(Skills.Bomb);
    }
    private void OnSkill2(InputValue _value)
    {
        UseSkill(Skills.Barricade);
    }
    private void OnSkill3(InputValue _value)
    {
        UseSkill(Skills.Upgrade);
    }
    private void OnDemolition(InputValue _value)
    {
        RemoveTower();
    }
    private void OnAttack(InputValue _value)
    {
        Attack(); 
    }
    
}