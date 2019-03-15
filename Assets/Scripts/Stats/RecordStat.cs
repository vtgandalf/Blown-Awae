using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordStat : Stat
{
    [Tooltip("Highest value is taken (lowest when unchecked)")]
    public bool HighestRecord;

    public RecordStat(Player player, string name, float value, bool highestRecord = true) : base(player, name, value)
    {
        HighestRecord = highestRecord;
    }

    public override void ChangeScore(Stat newScore)
    {
        if (!PlayerAndNameCorrect(newScore))
            return;

        if ((HighestRecord && newScore.Value > Value) ||
            (!HighestRecord && newScore.Value < Value))
        {
            Value = newScore.Value;
        }
    }
}
