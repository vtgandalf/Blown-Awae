using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Demolish", menuName = "Powerup/BombEffect/Demolish")]
public class DemolishBE : BombEffect
{
    public override void Activate(List<BombInteractable> hits)
    {
        base.Activate(hits);
        foreach (BombInteractable bi in hits)
        {
            if (bi.type == InteractableType.GROUND)
            {
                bi.GetComponent<Tile>().Fall();
            }
        }
    }
}
