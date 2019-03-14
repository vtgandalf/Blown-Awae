using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Score/Record")]
public class RecordScore : Score
{
    [Tooltip("Highest value is taken (lowest when unchecked)")]
    public bool HighestRecord;

    public override void ChangeScore(Score newScore)
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
