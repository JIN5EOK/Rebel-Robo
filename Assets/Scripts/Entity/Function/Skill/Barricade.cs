using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Barricade : Skill
{
    public override void Execute(Player _player, ref bool _isSuccese)
    {
        base.Execute(_player, ref _isSuccese);
        this.transform.position = _player.transform.position;

        RaycastHit hit;
        EnemyTile enemyTile = null;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 3.0f, 1 << LayerMask.NameToLayer("Tile")))
        {
            if (hit.transform.gameObject.TryGetComponent(out enemyTile))
            {
                if (enemyTile.AddEntity(this))
                {
                    StartCoroutine(SetTimer());
                    _isSuccese = true;

                    return;
                }
            }
        }

        _isSuccese = false;
        Destroyed();
        return;
    }

    IEnumerator SetTimer()
    {
        yield return new WaitForSeconds(3.0f);
        Destroyed();
    }
}
