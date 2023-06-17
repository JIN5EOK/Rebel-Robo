using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkMaterial : MonoBehaviour
{
    //김하늘 작성 23-06-17

    public Material originalMaterial; // 원본 
    public Material blinkMaterial; // 번쩍이는 메테리얼

    public float blinkInterval = 0.5f; // 번쩍 간격

    private Renderer objectRenderer;
    private bool isBlinking = false;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (!isBlinking)
        {
            StartCoroutine(BlinkCoroutine());
        }
    }

    private System.Collections.IEnumerator BlinkCoroutine()
    {
        isBlinking = true;

        Material original = objectRenderer.material;

        while (true)
        {
            objectRenderer.material = blinkMaterial;
            yield return new WaitForSeconds(blinkInterval);
            objectRenderer.material = original;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}