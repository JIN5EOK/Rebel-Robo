using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// By Jinseok Bae
/// <summary>
/// 플레이어 타워 설치를 방해하는 장애물
/// </summary>
public class Obstacle : Entity, IDemolitionable
{
    [SerializeField]
    protected ObstacleStatus status;

    // 에너지를 소모하여 파괴하기
    public void Demolition(ref int _energy)
    {
        if (status.Cost > _energy)
            return;

        _energy -= status.Cost;
        Destroyed();
    }
}
