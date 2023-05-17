using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// By Jinseok Bae
/// <summary>
/// 타워에게 필요한 스테이터스 데이터
/// </summary>
[CreateAssetMenu(fileName = "TowerStatus", menuName = "Scriptable Object/Status/TowerStatus", order = int.MaxValue)]
[Serializable]
public class TowerStatus : ScriptableObject
{
    [SerializeField]
    private float range;
    public float Range { get => range; }
    [SerializeField]
    private int dmg;
    public int Dmg { get => dmg; }
    [SerializeField]
    private float atkSpd;
    public float AtkSpd { get => atkSpd; }
    [SerializeField]
    private int cost;
    public int Cost { get => cost; }
    public int RefundCost
    {
        get => Cost / 2;
    }
}