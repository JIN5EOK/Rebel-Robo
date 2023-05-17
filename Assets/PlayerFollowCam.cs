using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCam : MonoBehaviour
{
    
    public Transform target; // 추적 대상
    public Vector3 offset = new Vector3(0f, 5f, -10f); // 카메라와 캐릭터 사이의 오프셋(거리)

    public float smoothSpeed = 0.125f; // 해당 변수를 조정하여 카메라의 부드러움 정도 조절 가능(인스펙터 뷰에서)

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // 추적할 대상의 위치에 오프셋을 더한 위치
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // 카메라 위치와 캐릭터 사이를 보간

        transform.position = smoothedPosition; // 카메라 위치 업데이트
        transform.LookAt(target); // 캐릭터를 향해 바라보도록 설정
    }
}