using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

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
        
        hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));

        if (Input.GetMouseButtonDown(0))
        {
            foreach (var hit in hits)
            {
                if (hit.transform.CompareTag("EnemyTile"))
                {
                    EnemyAlphaFactory.Instance.Spawn(EnemyAlphas.EnemyAlphaLv1, hit.transform.position + Vector3.up, Quaternion.identity);
                    break;
                }
                if (hit.transform.CompareTag("TowerTile"))
                {
                    MachinegunTowerFactory.Instance.Spawn(MachinegunTowers.MachinegunTowersLv1, hit.transform.position + Vector3.up, Quaternion.identity);
                    break;
                }
            }
            
        }
        
        
        if (Input.GetButton("Horizontal") == true || Input.GetButton("Vertical") == true)
        {
            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                inputDir += Vector3.right;
            }
            else if (Input.GetAxisRaw("Horizontal") == -1)
            {
                inputDir += Vector3.left;
            }
            if (Input.GetAxisRaw("Vertical") == 1)
            {
                inputDir += Vector3.forward;
            }
            else if (Input.GetAxisRaw("Vertical") == -1)
            {
                inputDir += Vector3.back;
            }
            
            inputDir = inputDir.normalized;
            player.Move(inputDir);
        }
    }
}