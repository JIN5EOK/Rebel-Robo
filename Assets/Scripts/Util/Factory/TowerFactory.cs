using System.Collections.Generic;

public enum Towers
{
    MachinegunTower,
    FlameTower,
    MissileTower
}
// 머신건 타워의 인스턴스를 제작하여 반환해주는 팩토리
public class TowerFactory : EntityFactory<Tower, Towers>
{
    private void Awake()
    {
        base.Awake();
        EntityAddresses = new Dictionary<Towers, string>();
        EntityAddresses.Add(Towers.MachinegunTower, "Assets/Prefabs/Entity/Tower/MachinegunTower2.prefab");
        EntityAddresses.Add(Towers.FlameTower, "Assets/Prefabs/Entity/Tower/FlameTower2.prefab");
        EntityAddresses.Add(Towers.MissileTower, "Assets/Prefabs/Entity/Tower/MissileTower2.prefab");
    }
}