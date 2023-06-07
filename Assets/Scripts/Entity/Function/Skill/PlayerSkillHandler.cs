using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerSkillHandler : MonoBehaviour
{
    [SerializeField] private Player player;
    private Dictionary<Skills, CoolTime> skillCoolTimes = new Dictionary<Skills, CoolTime>();

    private void Awake()
    {
        skillCoolTimes.Add(Skills.Bomb, new CoolTime(15.0f));
        skillCoolTimes.Add(Skills.Barricade, new CoolTime(15.0f));
        skillCoolTimes.Add(Skills.Upgrade, new CoolTime(15.0f));
    }
    private void Update()
    {
        SetCoolTime();
    }
    private void SetCoolTime()
    {
        foreach(CoolTime c in skillCoolTimes.Values)
        {
            
            c.CurCoolTime -= Time.deltaTime;
            Debug.Log(c.CurCoolTime);
        }
    }
    
    public void Execute(Skills _skillName)
    {
        if (skillCoolTimes[_skillName].IsComplete == false)
            return;
        
        Skill skill = SkillFactory.Instance.Spawn(_skillName, player.transform.position, Quaternion.identity);

        bool isSuccese = false;
        skill.Execute(player, ref isSuccese);
        if(isSuccese == true)
        {
            Debug.Log("스킬 사용 성공");
            skillCoolTimes[_skillName].Reset();
        }
    }

    public void AddSkillCoolTimeAction(Skills _skill, Action<float> _action)
    {
        skillCoolTimes[_skill].AddCoolTimeAction(_action);
    }
    public void RemoveSkillCoolTimeAction(Skills _skill, Action<float> _action)
    {
        skillCoolTimes[_skill].RemoveCoolTimeAction(_action);
    }
}
