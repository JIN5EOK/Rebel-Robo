using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AI;
using UnityEngine.ResourceManagement.AsyncOperations;

// By Jinseok Bae
/// <summary>
/// 엔터티 팩토리를 상속하여 만드는 적 유닛 팩토리 예시
/// </summary>
// 적 LV1, LV2, LV3를 생산함

public enum Enemys
{
    EnemyLv1,
    EnemyLv2,
    EnemyLv3
}
// Alpha의 인스턴스를 제작하여 반환해주는 팩토리
public class EnemyFactory : EntityFactory<Enemy, Enemys>
{
    private void Awake()
    {
        EntityAddresses = new Dictionary<Enemys, string>();
        
        EntityAddresses.Add(Enemys.EnemyLv1, "Assets/Prefabs/Entity/Enemy/EnemyLv1.prefab");
        EntityAddresses.Add(Enemys.EnemyLv2, "Assets/Prefabs/Entity/Enemy/EnemyLv2.prefab");
        EntityAddresses.Add(Enemys.EnemyLv3, "Assets/Prefabs/Entity/Enemy/EnemyLv3.prefab");
    }
}