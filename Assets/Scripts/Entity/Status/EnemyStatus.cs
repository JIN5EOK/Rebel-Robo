using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// By Jinseok Bae
/// <summary>
/// 적에게 필요한 스테이터스 데이터
/// </summary>

[CreateAssetMenu(fileName = "EnemyStatus", menuName = "Scriptable Object/Status/EnemyStatus", order = int.MaxValue)]
public class EnemyStatus : ScriptableObject
{
    private EnemyStatus() {}
    [SerializeField] private float moveSpd;
    public float MoveSpd { get => moveSpd; }
    [SerializeField] private int maxHp;
    public int MaxHp { get => maxHp; }
    [SerializeField] private int dmg;
    public int Dmg { get => dmg; }
}