using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// By Jinseok Bae
/// <summary>
/// 투사체를 생상하는 팩토리
public enum TowerProjectiles
{
    Bullet,
    Missile,
    Flame
}
public class TowerProjectileFactory : EntityFactory<TowerProjectile, TowerProjectiles>
{

    private void Awake()
    {
        base.Awake();
        EntityAddresses = new Dictionary<TowerProjectiles, string>();
        EntityAddresses.Add(TowerProjectiles.Bullet, "Assets/Prefabs/Entity/Projectile/Tower/Bullet.prefab");
        EntityAddresses.Add(TowerProjectiles.Missile, "Assets/Prefabs/Entity/Projectile/Tower/Missile.prefab");
        EntityAddresses.Add(TowerProjectiles.Flame, "Assets/Prefabs/Entity/Projectile/Tower/Flame.prefab");
    }
}
