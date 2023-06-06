using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //2023-05-14 김하늘 작성
    
    public Transform player;
    public float distance = 5f; // 카메라와 플레이어 사이 거리
    public float height = 3f; // 카메라 높이
    public float smoothSpeed = 10f; // 보간

    private Vector3 offset; // 상대적 위치

    private void Start()
    {
        offset = new Vector3(0f, height, -distance);
    }

    private void LateUpdate()
    {
        // 플레이어의 위치에 오프셋을 더해 카메라의 목표 위치 설정
        Vector3 targetPosition = player.position + offset;

        // 보간 사용
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
