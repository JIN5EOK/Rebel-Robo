using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyItem : Item
{
    [SerializeField] int energy;
    protected override void GetItem()
    {
        player.Energy += energy;
    }
}
