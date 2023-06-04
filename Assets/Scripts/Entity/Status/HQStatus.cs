using System;
using UnityEngine;
// By Jinseok Bae
/// <summary>
/// HQ에게 필요한 스테이터스 데이터
/// </summary>

[CreateAssetMenu(fileName = "HQStatus", menuName = "Scriptable Object/Status/HQStatus", order = int.MaxValue)]
[Serializable]
public class HQStatus : ScriptableObject
{
    private HQStatus() { }

    [SerializeField] private int maxHp;
    public int MaxHp { get => maxHp; }
}