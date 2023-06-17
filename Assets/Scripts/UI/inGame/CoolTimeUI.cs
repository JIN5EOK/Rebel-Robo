using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoolTimeUI : MonoBehaviour
{
    // ����׸� ���� �ӽ÷� SkillHandler�� �ν����Ϳ��� ����� �����ϵ��� ����, ���߿� �ٸ� ������� �����ϰ� ���� �ʿ��� 
    [SerializeField]
    private PlayerSkillHandler playerSkillHandler;
    private Image image;
    [SerializeField] private Skills skill;

    private void Start()
    {
        image = GetComponent<Image>();
        playerSkillHandler.AddSkillCoolTimeAction(skill, (float _value) => image.fillAmount = _value);
        
    }
}