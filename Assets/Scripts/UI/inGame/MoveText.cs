using UnityEngine;
using TMPro;

public class MoveText : MonoBehaviour
{
    public float speed = 20f; // 이동 속도
    public float fadeSpeed = 1f; // 페이드 아웃 속도
    public float destroyDelay = 3f; // 삭제 딜레이

    private Player player;
    public TextMeshProUGUI textMesh;
    private float alpha = 1f;
    private float timer = 0f;
    private bool isFading = false;
    private bool isDestroying = false;

    private Vector3 initialPosition;

    private void Start()
    {
        textMesh = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        initialPosition = transform.position;
    }

    // private void Move()
    // {
    //     transform.Translate(Vector3.up * speed * Time.deltaTime);
    //     timer += Time.deltaTime;
    // }

    private void FadeOut()
    {
        alpha -= fadeSpeed * Time.deltaTime;
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, alpha);
    }

    public void StartFading()
    {
        isFading = true;
    }

    public void MoveTextOnEnergyChange(int energy)
    {
        //if (isUsing == true)
          //  return;
        
        Transform child = transform.GetChild(0);
        child.gameObject.SetActive(true);
        textMesh.text = energy.ToString();

        // 초기화
        alpha = 1f;
        timer = 0f;
        isFading = false;
        isDestroying = false;

        StartCoroutine(MoveAndFade());
    }


    //private bool isUsing = false;
    private System.Collections.IEnumerator MoveAndFade()
    {
        //isUsing = true;
        // while (timer < destroyDelay)
        // {
        //     Move();
        //     yield return null;
        // }

        isFading = true;

        while (alpha > 0f)
        {
            FadeOut();
            yield return null;
        }

        Transform child = transform.GetChild(0);
        child.gameObject.SetActive(false);
        //isUsing = false;
        
    }
}