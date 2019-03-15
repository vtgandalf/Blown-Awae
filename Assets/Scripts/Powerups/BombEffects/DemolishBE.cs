using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Demolish", menuName = "Powerup/BombEffect/Demolish")]
public class DemolishBE : BombEffect
{
    public override void Activate(List<BombInteractable> hits)
    {
        base.Activate(hits);
        int tilesAltered = 0;
        foreach (BombInteractable bi in hits)
        {
            if (bi.type == InteractableType.GROUND)
            {
                bi.GetComponent<Tile>().Fall();
                tilesAltered++;
            }
        }

        Owner.StatTracker.AddStat(new CountStat(Owner, "tilesAltered", tilesAltered));
    }
}
