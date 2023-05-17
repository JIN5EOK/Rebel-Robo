using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;


public class MapEditor : MonoBehaviour
{
    public enum Tiles
    {
        TowerTile,
        EnemyTile
    }

    public enum Entitys
    {
        PlayerHQ,
        Player,
        Obstacle
    }
    [Header("Select")]
    public Tiles selectTile;
    public Entitys selectEntity;
    [Header("Prefabs")]
    public GameObject[] tilePrefabs;
    public GameObject[] entityPrefabs;
    [Header("Grid Setting")]
    public float cellSize = 1.0f;
    public Color gridColor = Color.black;
    public int tileY = -1;
    public int entityY = 0;
    Vector2 center;
    private uint size = 1000;
    private float gridY = -1;
    private void BakeMesh()
    {
        NavMeshSurface[] navs = transform.GetChild(0).GetComponentsInChildren<NavMeshSurface>();

        foreach (NavMeshSurface n in navs)
        {
            if (n.CompareTag("EnemyTile") == true)
            {
                n.RemoveData();
                n.BuildNavMesh();       
            }
        }
    }
    public void Start() // 런타임시 네비메쉬 베이크 및 맵 에디터 파괴
    { 
        BakeMesh();
        Destroy(this);
    }
    private void OnDrawGizmosSelected() // 오브젝트를 선택했을때만 기즈모 그리기
    {
        if (cellSize <= 0.0f) cellSize = 0.01f;
            
        Gizmos.color = gridColor;
        center = this.transform.GetChild(0).transform.position;
        float startX = center.x - ((size / 2.0f) * cellSize);
        float endX = center.x + ((size / 2.0f) * cellSize);
        float startZ = center.y - ((size / 2.0f) * cellSize);
        float endZ = center.y + ((size / 2.0f) * cellSize);

        for (float x = startX; x < endX; x += cellSize)
        {
            Gizmos.DrawLine(new Vector3(x, gridY,startZ), new Vector3(x, gridY,endZ));
        }
        for (float z = startZ; z < endZ; z += cellSize)
        {
            Gizmos.DrawLine(new Vector3(startX, gridY,z), new Vector3(endX, gridY,z));
        }   
    }
}
