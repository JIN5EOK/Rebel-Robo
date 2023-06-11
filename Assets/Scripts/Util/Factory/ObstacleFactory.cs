using System.Collections.Generic;

public enum Obstacles
{
    Obstacle
}
// 머신건 타워의 인스턴스를 제작하여 반환해주는 팩토리
public class ObstacleFactory : EntityFactory<Obstacle, Obstacles>
{
    private void Awake()
    {
        EntityAddresses = new Dictionary<Obstacles, string>();
        EntityAddresses.Add(Obstacles.Obstacle, "Assets/Prefabs/Entity/Obstacle/Obatacle.prefab");
    }
}