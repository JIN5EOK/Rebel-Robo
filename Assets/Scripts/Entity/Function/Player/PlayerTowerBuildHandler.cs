using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTowerBuildHandler : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField]private Transform center;
    Dictionary<Towers, int> buildCost = new Dictionary<Towers, int>();

    [SerializeField]private Sfxs buildSound;
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
        Debug.Log("체크");
        if (Physics.Raycast(center.position, Vector3.down, out hit, 3.0f,  1<<LayerMask.NameToLayer("Tile")))
        {
            Debug.Log("성공");
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
            AudioManager.Instance.PlaySfx(buildSound, this.transform);
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
