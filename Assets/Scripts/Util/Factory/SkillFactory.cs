using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// By Jinseok Bae
/// <summary>
/// 투사체를 생상하는 팩토리
public enum Skills
{
    Bomb,
    Barricade,
    Upgrade
}
public class SkillFactory : EntityFactory<Skill, Skills>
{
    private void Awake()
    {
        base.Awake();
        EntityAddresses = new Dictionary<Skills, string>();
        EntityAddresses.Add(Skills.Bomb, "Assets/Prefabs/Entity/Skill/Bomb.prefab");
        EntityAddresses.Add(Skills.Barricade, "Assets/Prefabs/Entity/Skill/Barricade.prefab");
    }
}
