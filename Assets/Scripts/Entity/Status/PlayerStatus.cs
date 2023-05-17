using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// By Jinseok Bae
/// <summary>
/// 플레이어에게 필요한 스테이터스 데이터
/// </summary>
[CreateAssetMenu(fileName = "PlayerStatus", menuName = "Scriptable Object/Status/PlayerStatus", order = int.MaxValue)]
[Serializable]
public class PlayerStatus : ScriptableObject
{
    private PlayerStatus() { }
    [SerializeField]
    private float moveSpd;
    public float MoveSpd { get => moveSpd ; }
    [SerializeField]
    private int maxEnergy;
    public int MaxEnergy { get => maxEnergy; }
}