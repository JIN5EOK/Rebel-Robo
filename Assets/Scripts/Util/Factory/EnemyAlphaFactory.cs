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
// 가상의 적 이름 Alpha의 Lv1버전, Lv2버전 바리에이션

public enum EnemyAlphas
{
    EnemyAlphaLv1,
    EnemyAlphaLv2
}
// Alpha의 인스턴스를 제작하여 반환해주는 팩토리
public class EnemyAlphaFactory : EntityFactory<Enemy, EnemyAlphas>
{
    private void Awake()
    {
        EntityAddresses = new Dictionary<EnemyAlphas, string>();
        
        EntityAddresses.Add(EnemyAlphas.EnemyAlphaLv1, "Assets/Prefabs/Entity/Enemy/EnemyAlphaLv1.prefab");
        EntityAddresses.Add(EnemyAlphas.EnemyAlphaLv2, "Assets/Prefabs/Entity/Enemy/EnemyAlphaLv2.prefab");
    }
}