using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
// By Jinseok Bae
public class MachinegunTower : Tower
{
    private float AttackCoolTime = 0.0f;

    private Enemy target;
    private List<Enemy> onRangeTargets = new List<Enemy>();
    
    private SphereCollider rangeCol;
    private void Start()
    {
        
        rangeCol = gameObject.AddComponent<SphereCollider>();
        rangeCol.isTrigger = true;
        rangeCol.radius = status.Range;
    }

    private void Update()
    {
        AttackTimer();
    }

    private void AttackTimer()
    {
        if (AttackCoolTime < status.AtkSpd)
        {
            AttackCoolTime += Time.deltaTime;
            return;
        }

        if (target != null)
        {
            AttackCoolTime = 0.0f;
            Attack(target);
        }
    }

    /*
     * 적이 공격범위 안에 들어왔을때 1회 작동, 공격범위 후보 리스트에 등록하고 타겟을 해제하는 함수(OutRange)를
     * 적이 비활성화시 작동하는 액션 리스트에 등록하여 적이 공격 범위를 나가기 전에 파괴하거나 비활성화 될 경우
     * 후보에서 제거하여 공격후보 리스트에 Missing GameObject가 담기는 일이 없도록 함.
     */

    protected override void OnRange(Entity _target)
    {
        Enemy enemy = _target as Enemy;
        if(onRangeTargets.Contains(enemy) == false)
        {
            enemy.AddDisableAction(OutRange);
            onRangeTargets.Add(enemy);
        }
        if(target == null)
            target = enemy;
    }
    /*
     * 적이 공격범위를 나갔을 때나 공격범위안에 있던 도중 파괴,비활성화 될 경우 1회 작동, 공격범위 후보 리스트에서 제거하고   
     * 비활성화 액션 리스트에서 OutRange함수를 제거하여 관계를 끊는다, 만약 공격범위에서 사라진 적이 공격타겟이었을 경우
     * 공격후보중 하나를 가져와 다음 타겟으로 삼는다.
     */
    protected override void OutRange(Entity _target)
    {
        Enemy enemy = _target as Enemy;
        if(onRangeTargets.Contains(enemy))
        {
            onRangeTargets.Remove(enemy);
            enemy.RemoveDisableAction(OutRange);
        }
        if (enemy == target)
        {
            target = null;
            if(onRangeTargets.Count > 0)
                target = onRangeTargets[0];
        }
    }
    protected override void Attack(Enemy _target)
    {
        Debug.Log("공격");
        _target.Damaged(status.Dmg);
    }

    private void OnTriggerEnter(Collider _targetCol)
    {
        if (_targetCol.transform.gameObject.layer != LayerMask.NameToLayer("Enemy"))
            return;
        
        Enemy targetEnemy;
        if (_targetCol.TryGetComponent(out targetEnemy))
        {
            OnRange(targetEnemy);
        }
    }

    private void OnTriggerExit(Collider _targetCol)
    {
        if (_targetCol.transform.gameObject.layer != LayerMask.NameToLayer("Enemy"))
            return;
        
        Enemy targetEnemy;
        if (_targetCol.TryGetComponent(out targetEnemy))
        {
            OutRange(targetEnemy);
        }
        
    }

    private void OnDrawGizmos()
    {
        if (target != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(this.transform.position, target.transform.position);
        }
            
    }
}
