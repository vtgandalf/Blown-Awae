using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountStat : Stat
{
    public CountStat(Player player, string name, float value) : base(player, name, value) {}

    public override void ChangeScore(Stat newScore)
    {
        if (!PlayerAndNameCorrect(newScore))
            return;

        Value += newScore.Value;
    }
}
