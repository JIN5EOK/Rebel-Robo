using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//김하늘 작성
public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // 방해물 프리팹
    public float spawnDelay = 10f; // 생성 시간
    public int maxObstacles = 4; // 방해물 개수 제한

    private GameObject[] towerTiles; // TowerTile 태크 타일
    private List<GameObject> spawnedObstacles = new List<GameObject>(); // 생성방해물 리스트에 저장
    private void Start()
    {
        towerTiles = GameObject.FindGameObjectsWithTag("TowerTile");
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            if (spawnedObstacles.Count >= maxObstacles)
            {
                yield return null;
                continue;
            } //최대 개수에 도달하면 스폰 중산

            // T랜덤 바닥 선택
            GameObject randomTile = towerTiles[Random.Range(0, towerTiles.Length)];

            // 방해물 생성 타일 제외
            if (randomTile.transform.childCount > 0)
            {
                yield return null;
                continue;
            }

            int randomIndex = Random.Range(0, obstaclePrefabs.Length);

            GameObject obstacle = Instantiate(obstaclePrefabs[randomIndex], randomTile.transform.position, Quaternion.identity);
            obstacle.transform.SetParent(randomTile.transform);

            spawnedObstacles.Add(obstacle);

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
