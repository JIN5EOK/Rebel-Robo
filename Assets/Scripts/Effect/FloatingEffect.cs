using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    public float floatingSpeed = 1f; // 둥둥거리는 속도
    public float floatingHeight = 1f; // 떠있는 높이

    private float original; // 물체위치

    private void Start()
    {
        original = transform.position.y;
    }

    private void Update()
    {
        //Sin 함수를 사용해 y 위치를 변
        float newY = original + Mathf.Sin(Time.time * floatingSpeed) * floatingHeight;

        // 객체 위치 업데이트
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
