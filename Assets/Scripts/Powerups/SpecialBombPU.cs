using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Special Bomb", menuName = "Powerup/SpecialBomb")]
public class SpecialBombPU : Powerup
{
    public BombEffect bombEffect;

    public override void Apply(Player player)
    {
        base.Apply(player);
        player.SetBombEffect(bombEffect);
    }
}
