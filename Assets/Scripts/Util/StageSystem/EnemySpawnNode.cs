using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemySpawnNode
{
    [SerializeField] private Enemys spawnEnemy;
    [SerializeField] private float waitTime;

    public Enemys SpawnEnemy
    {
        get => spawnEnemy;
    }
    public float WaitTime
    {
        get => waitTime;
    }
}
