using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : Skill
{
    //해당 부분 김하늘 작성 06-18
    public GameObject explosion; //폭발 효과 프리팹 할당


    public override void Execute(Player _player, ref bool _isSuccese)
    {
        base.Execute(_player, ref _isSuccese);
        this.transform.position = _player.transform.position;

        StartCoroutine(SetBoom());
        _isSuccese = true;
    }



    IEnumerator SetBoom()
    {
        yield return new WaitForSeconds(1.0f);
        Boom();
    }

    private void Boom()
    {
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(this.transform.position, 4.0f, Vector3.up, 0.0f ,1 << LayerMask.NameToLayer("Enemy"),QueryTriggerInteraction.Collide);

        Enemy enemy;
        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.TryGetComponent(out enemy))
            {
                enemy.Damaged(10);
                    
            }
            Debug.Log(hit.transform.name);
        }

        //김하늘 작성

        Destroyed();
         GameObject tmp = Instantiate(explosion, this.transform.position, Quaternion.identity);
         Destroy(tmp, 0.2f);
             }
}
