using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPositions;
    [SerializeField] private EnemyWave[] waves;

    public Action<int> ChangeMaxWaveCnt;
    public Action<int> ChangeCurEnemyCnt;
    public Action<int> ChangeMaxEnemyCnt;
    public Action<int> ChangeWaveCnt;
    public Action OnGameClear;
    private EnemyWave curWave;

    private int maxWaveCnt;
    private int curWaveCnt;

    private float GenObstalceTime = 10; 
    private int maxObstacleCnt;
    private int curObstacleCnt;

    private TowerTile[] towerTiles;
    private int MaxWaveCnt
    {
        get => maxWaveCnt;
        set
        {
            maxWaveCnt = value;
            ChangeMaxWaveCnt.Invoke(value);
        }
    }
    private int CurWaveCnt
    {
        get => curWaveCnt;
        set
        {
            curWaveCnt = value;
            ChangeWaveCnt.Invoke(value);
        }
    }

    private int CurEnemyCount
    {
        get => curWave.CurEnemyCount;
        set
        {
            curWave.CurEnemyCount = value;  
            ChangeCurEnemyCnt.Invoke(value);
        } 
    }
    private int MaxEnemyCount
    {
        get => curWave.MaxEnemyCount;
        set
        {
            curWave.MaxEnemyCount = value;
            ChangeMaxEnemyCnt.Invoke(value);
        }
    }
    private void Start()
    {
        towerTiles = FindObjectsOfType<TowerTile>();
        maxObstacleCnt = towerTiles.Length / 3; // 장애물은 최대 타일의 1/3만큼만 생성하도록
        foreach (EnemyWave w in waves)
        {
            w.Init();
        }
        
        StartCoroutine(WaveProgress());
    }

    private IEnumerator MakingObstacle()
    {
        Obstacle obstacle = null;
        int tileIdx;
        while (true)
        {
            yield return new WaitForSeconds(GenObstalceTime);

            if (curObstacleCnt < maxObstacleCnt)
            {
                while (obstacle == null)
                {
                    tileIdx = Random.Range(0, towerTiles.Length - 1);
                    obstacle = ObstacleFactory.Instance.Spawn(Obstacles.Obstacle, towerTiles[tileIdx],
                        Quaternion.identity);
                }
                curObstacleCnt++;
            }
        }
    }
    
    private IEnumerator WaveProgress()
    {
        for (int i = 3; i >= 1; i--)
        {
            Debug.Log(i + "초 후 게임 시작");
            yield return new WaitForSeconds(1.0f);
        }
        Func<Vector3> GetRandomPos = () => spawnPositions[Random.Range(0, spawnPositions.Count)].position;
        MaxWaveCnt = waves.Length;
        CurWaveCnt = 1;
        foreach (EnemyWave w in waves)
        {
            StartCoroutine(MakingObstacle());
            curWave = w;
            MaxEnemyCount = MaxEnemyCount;
            CurEnemyCount = CurEnemyCount;
            EnemySpawnNode spawnNd = curWave.NextNode();
            while (spawnNd != null)
            {
                Enemy enemy = EnemyFactory.Instance.Spawn(spawnNd.SpawnEnemy, GetRandomPos.Invoke(), Quaternion.identity);
                enemy.DisableActions += (e) => CurEnemyCount--;
                yield return new WaitForSeconds(spawnNd.WaitTime);
                spawnNd = curWave.NextNode();
            }

            while (CurEnemyCount > 0)
            {
                yield return null;
            }

            if (maxWaveCnt > curWaveCnt)
            {
                for (int i = 10; i >= 1; i--)
                {
                    Debug.Log(i + "초 후 다음 웨이브 시작");
                    yield return new WaitForSeconds(1.0f);
                }
                CurWaveCnt++;    
            }
            StopCoroutine(MakingObstacle());
        }

        if(OnGameClear != null)
            OnGameClear.Invoke();
        Debug.Log("게임 클리어");
    }

}
