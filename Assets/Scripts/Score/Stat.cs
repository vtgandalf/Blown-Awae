using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stat
{
    public readonly Player Player;
    public readonly string Name;
    public float Value { get; protected set; }

    public Stat(Player player, string name, float value)
    {
        Player = player;
        Name = name;
        Value = value;
    }

    public abstract void ChangeScore(Stat newScore);

    protected bool PlayerAndNameCorrect(Stat newScore)
    {
        if (Player == newScore.Player && Name == newScore.Name)
            return true;
        return false;
    }
}
