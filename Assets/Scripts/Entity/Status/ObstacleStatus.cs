using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// By Jinseok Bae
/// <summary>
/// 장애물에게 필요한 스테이터스 데이터
/// </summary>
[CreateAssetMenu(fileName = "ObstacleStatus", menuName = "Scriptable Object/Status/ObstacleStatus", order = int.MaxValue)]
[Serializable]
public class ObstacleStatus : ScriptableObject
{
    private ObstacleStatus() { }

    [SerializeField]
    private int cost;
    public int Cost { get => cost; } // 철거에 필요한 가격
}