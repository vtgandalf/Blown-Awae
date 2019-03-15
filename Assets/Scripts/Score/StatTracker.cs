using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class StatTracker : ScriptableObject
{
    private readonly List<Stat> stats = new List<Stat>();

    public void AddStat(Stat newStat)
    {
        //List<Stat> scores;
        //// If Player is NOT in playerScores...
        //if (!stats1.TryGetValue(newScore.Player, out scores))
        //{
        //    // ...add player to playerScores
        //    stats1[newScore.Player] = new List<Stat>();
        //    scores = stats1[newScore.Player];
        //}

        Stat stat = null;
        foreach (Stat s in stats)
        {
            if (s.Name == newStat.Name)
            {
                stat = s;
                break;
            }
        }
        if (stat != null)
            stat.ChangeScore(newStat);
        else stats.Add(newStat);
    }

    //public List<Stat> GetScoresByPlayer(Player player)
    //{
    //    List<Stat> scoresFromPlayer = new List<Stat>();
    //    stats.TryGetValue(player, out scoresFromPlayer);

    //    return scoresFromPlayer;
    //}

    public Stat GetStatByName(string name)
    {
        foreach (Stat s in stats)
        {
            if (s.Name == name)
                return s;
        }
        return null;
    }
}
