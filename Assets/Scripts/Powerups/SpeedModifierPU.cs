using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Speed Modifier", menuName = "Powerup/SpeedModifier")]
public class SpeedModifierPU : Powerup
{
    public float speedBonus;
    public float weightBonus;

    public override void Apply(Player player)
    {
        base.Apply(player);
        player.AddSpeed(speedBonus);
        player.AddWeight(weightBonus);
    }
}
