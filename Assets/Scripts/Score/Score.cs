using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Score : ScriptableObject
{
    public Player Player;
    public string Name;
    public float Value;

    public void SetupScore(Player player, string name, float value)
    {
        Player = player;
        Name = name;
        Value = value;
    }

    public abstract void ChangeScore(Score newScore);

    protected bool PlayerAndNameCorrect(Score newScore)
    {
        if (Player == newScore.Player && Name == newScore.Name)
            return true;
        return false;
    }
}
