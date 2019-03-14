using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Score/Count")]
public class CountScore : Score
{
    public override void ChangeScore(Score newScore)
    {
        if (!PlayerAndNameCorrect(newScore))
            return;

        Value += newScore.Value;
    }
}
