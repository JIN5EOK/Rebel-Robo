using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTowerBuildHandler : MonoBehaviour
{
    [SerializeField] private Player player;
    
    Dictionary<Towers, int> buildCost = new Dictionary<Towers, int>();
    void Awake()
    {
        buildCost.Add(Towers.MachinegunTower,50);
        buildCost.Add(Towers.FlameTower,100);
        buildCost.Add(Towers.MissileTower,100);
    }

    TowerTile TowerTileCheck()
    {
        RaycastHit hit;
        TowerTile towerTile = null;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 3.0f, LayerMask.GetMask("Tile")))
        {
            hit.transform.gameObject.TryGetComponent<TowerTile>(out towerTile);
        }
        return towerTile;
    }
    
    public bool BuildTower(Towers _tower)
    {
        TowerTile towerTile = TowerTileCheck();

        if (towerTile == null)
            return false;
        
        if (towerTile.Entity != null)
            return false;

        
        int cost;
        if (buildCost.TryGetValue(_tower, out cost) == true)
        {
            if (cost > player.Energy)
            {
                return false;
            }

            player.Energy -= cost;
            towerTile.AddEntity(TowerFactory.Instance.Spawn(_tower, transform.position, Quaternion.identity));
            return true;
        }
        return false;
    }

    public bool RemoveTower()
    {
        TowerTile towerTile = TowerTileCheck();

        if (towerTile == null)
            return false;
        if (towerTile.Entity == null)
            return false;
        if (towerTile.Entity.GetType() == typeof(Tower))
        {
            Tower tower = (Tower)towerTile.Entity;
            int tempEnergy = player.Energy;
            towerTile.RemoveEntity(tower);
            tower.Demolition(ref tempEnergy);
            player.Energy = tempEnergy;
            return true;
        }
        return true;
    }
}
