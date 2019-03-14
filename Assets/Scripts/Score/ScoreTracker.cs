using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScoreTracker : ScriptableObject
{
    public Dictionary<Player, List<Score>> playerScores;

    public void AddScore(Score newScore)
    {
        List<Score> scores;
        // If Player is NOT in playerScores...
        if (!playerScores.TryGetValue(newScore.Player, out scores))
        {
            // ...add player to playerScores
            playerScores[newScore.Player] = new List<Score>();
            scores = playerScores[newScore.Player];
        }

        Score score = null;
        foreach (Score s in scores)
        {
            if (s.Name == newScore.Name)
            {
                score = s;
                break;
            }
        }
        if (score != null)
            score.ChangeScore(newScore);
        else scores.Add(newScore);
    }

    public List<Score> GetScoresByPlayer(Player player)
    {
        List<Score> scoresFromPlayer = new List<Score>();
        playerScores.TryGetValue(player, out scoresFromPlayer);

        return scoresFromPlayer;
    }

    public List<Score> GetScoresByName(string name)
    {
        List<Score> scoresWithName = new List<Score>();
        foreach (List<Score> scores in playerScores.Values)
        {
            foreach (Score s in scores)
            {
                if (s.Name == name)
                {
                    scoresWithName.Add(s);
                }
            }
        }
        return scoresWithName;
    }

    private void OnEnable()
    {
        if (playerScores == null)
            playerScores = new Dictionary<Player, List<Score>>();
    }
}
