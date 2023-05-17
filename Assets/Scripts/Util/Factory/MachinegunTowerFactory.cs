using System.Collections.Generic;

public enum MachinegunTowers
{
    MachinegunTowersLv1,
    MachinegunTowersLv2
}
// 머신건 타워의 인스턴스를 제작하여 반환해주는 팩토리
public class MachinegunTowerFactory : EntityFactory<Tower, MachinegunTowers>
{
    private void Awake()
    {
        EntityAddresses = new Dictionary<MachinegunTowers, string>();
        EntityAddresses.Add(MachinegunTowers.MachinegunTowersLv1, "Assets/Prefabs/Entity/Tower/MachinegunTowerLv1.prefab");
        EntityAddresses.Add(MachinegunTowers.MachinegunTowersLv2, "Assets/Prefabs/Entity/Tower/MachinegunTowerLv2.prefab");
    }
}