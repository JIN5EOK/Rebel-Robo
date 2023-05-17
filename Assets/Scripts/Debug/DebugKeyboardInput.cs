using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// 디버그용 임시 스크립트
/// </summary>
public class DebugKeyboardInput : MonoBehaviour
{
    [SerializeField] private Player player;
    Vector3 inputDir = new Vector3();

    private void Start()
    {
        player = FindObjectOfType<Player>();
        
        if(player == null)
            Destroy(this);
    }

    private void Update()
    {
        
        RaycastHit[] hits;

        hits = Physics.RaycastAll(player.transform.position, Vector3.down, 3.0f);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (var hit in hits)
            {
                if (hit.transform.CompareTag("TowerTile"))
                {
                    TowerFactory.Instance.Spawn(Towers.MissileTower, hit.transform.position + Vector3.up, Quaternion.identity);
                    break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (var hit in hits)
            {
                if (hit.transform.CompareTag("TowerTile"))
                {
                    TowerFactory.Instance.Spawn(Towers.FlameTower, hit.transform.position + Vector3.up, Quaternion.identity);
                    break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            foreach (var hit in hits)
            {
                if (hit.transform.CompareTag("TowerTile"))
                {
                    TowerFactory.Instance.Spawn(Towers.MissileTower, hit.transform.position + Vector3.up, Quaternion.identity);
                    break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            foreach (var hit in hits)
            {
                if (hit.transform.CompareTag("EnemyTile"))
                {
                    EnemyFactory.Instance.Spawn(Enemys.EnemyLv1, hit.transform.position + Vector3.up, Quaternion.identity);
                    break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            foreach (var hit in hits)
            {
                if (hit.transform.CompareTag("EnemyTile"))
                {
                    EnemyFactory.Instance.Spawn(Enemys.EnemyLv2, hit.transform.position + Vector3.up, Quaternion.identity);
                    break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            foreach (var hit in hits)
            {
                if (hit.transform.CompareTag("EnemyTile"))
                {
                    EnemyFactory.Instance.Spawn(Enemys.EnemyLv3, hit.transform.position + Vector3.up, Quaternion.identity);
                    break;
                }
            }
        }

    }
    
}
