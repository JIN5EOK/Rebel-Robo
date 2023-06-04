using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillUI : MonoBehaviour
{
    // 디버그를 위해 임시로 SkillHandler를 인스펙터에서 끌어다 참조하도록 만듦, 나중에 다른 방법으로 접근하게 수정 필요함 
    [SerializeField]
    private PlayerSkillHandler playerSkillHandler;
    private Image image;
    [SerializeField] private Skills skill;

    private void Start()
    {
        image = GetComponent<Image>();
        playerSkillHandler.AddSkillCoolTimeAction(skill, (float _value) => image.fillAmount = 1 - _value);
    }
}
