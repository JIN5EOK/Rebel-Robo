using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyWave
{
    [SerializeField]
    private Queue<EnemySpawnNode> nodeQueue;

    [SerializeField] private EnemySpawnNode[] enemySpawnNode;

    public int CurEnemyCount { get; set; }
    public int MaxEnemyCount { get; set; }

    public EnemySpawnNode NextNode()
    {
        if (nodeQueue.Count > 0)
            return nodeQueue.Dequeue();
        else
            return null;
    }
    
    public void Init()
    {
        nodeQueue = new Queue<EnemySpawnNode>();
        
        foreach (EnemySpawnNode n in enemySpawnNode)
        {
            nodeQueue.Enqueue(n);  
        }

        CurEnemyCount = nodeQueue.Count;
        MaxEnemyCount = nodeQueue.Count;
    }
}
