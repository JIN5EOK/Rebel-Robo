using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SkillUI : MonoBehaviour
{
    // 디버그를 위해 임시로 SkillHandler를 인스펙터에서 끌어다 참조하도록 만듦, 나중에 다른 방법으로 접근하게 수정 필요함 
    [SerializeField] GameObject PlayerObj;    
    
    private Player player;

    [SerializeField] private Image image;
    [SerializeField] private Skills skill;
    [SerializeField] TextMeshProUGUI count;
    private PlayerSkillHandler skillHandler;
    private void Start()
    {
        player = PlayerObj.GetComponent<Player>();
        skillHandler = player.GetPlayerSkillHandler();

        image = image.GetComponent<Image>();

        count.text = "";

    }
    private void Update()
    {
        if (skillHandler != null)
        {
            skillHandler.AddSkillCoolTimeAction(skill, (float _value) => StartCoroutine(CoolTimeCor(15f)));
        }
            
    }

    IEnumerator CoolTimeCor(float cool)
    {
        Debug.Log("코루틴 시작");

        while (cool > 1.0f)
        {
            cool -= Time.deltaTime;
            image.fillAmount = (1.0f / cool);
            count.text = (15f-cool).ToString();
            yield return new WaitForFixedUpdate();
        }

        Debug.Log("코루틴 종료");
    }
}
