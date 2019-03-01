using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Slippery", menuName = "Powerup/BombEffect/Slippery")]
public class SlipperyBE : BombEffect
{
    public Color tileColor;

    public override void Activate(List<BombInteractable> hits)
    {
        base.Activate(hits);
        foreach (BombInteractable bi in hits)
        {
            if (bi.type == InteractableType.GROUND)
            {
                Tile tile = bi.GetComponent<Tile>();
                tile.SetSlippery(true);
                tile.ChangeColor(tileColor);
            }
        }
    }
}
