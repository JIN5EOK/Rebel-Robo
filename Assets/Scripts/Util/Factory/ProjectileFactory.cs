using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// By Jinseok Bae
/// <summary>
/// 투사체를 생상하는 팩토리
public enum Projectiles
{
    Bullet,
    Missile,
    Laser,
    Flame
}
public class ProjectileFactory : EntityFactory<Projectile, Projectiles>
{

    private void Awake()
    {
        EntityAddresses = new Dictionary<Projectiles, string>();
        
        EntityAddresses.Add(Projectiles.Bullet, "Assets/Prefabs/Entity/Projectile/Bullet.prefab");
        EntityAddresses.Add(Projectiles.Flame, "Assets/Prefabs/Entity/Projectile/Flame.prefab");
        EntityAddresses.Add(Projectiles.Missile, "Assets/Prefabs/Entity/Projectile/Missile.prefab");
    }
}
