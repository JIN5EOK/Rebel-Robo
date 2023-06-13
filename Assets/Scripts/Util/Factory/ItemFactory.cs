using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 아이템을 생성하는 팩토리
public enum Items
{
    Energy
}
public class ItemFactory : EntityFactory<Item, Items>
{
    private void Awake()
    {
        base.Awake();
        EntityAddresses = new Dictionary<Items, string>();
        EntityAddresses.Add(Items.Energy, "Assets/Prefabs/Entity/Item/Bottle_Mana.prefab");
    }
}
