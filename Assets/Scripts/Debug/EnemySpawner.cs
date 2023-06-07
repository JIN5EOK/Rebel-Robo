using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs; // 스폰할 프리팹 배열
    public float spawnInterval = 10f; // 스폰 간격
    
    private void Start()
    {
        // 코루틴 시작
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            // 랜덤하게 적 스폰
            int randomIndex = Random.Range(0, objectPrefabs.Length);
            GameObject spawnedObject;

            if (objectPrefabs.Length > 0)
            {
                spawnedObject = Instantiate(objectPrefabs[randomIndex], transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("지정된 프리팹이 없음!");
                yield break; // 프리팹이 없는 경우 반복 종료
            }

            // 지정 간격마다 반복
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}