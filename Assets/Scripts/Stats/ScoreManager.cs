using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private List<RecordStat> confirmedKills = new List<RecordStat>();
    public List<Player> allPlayers = new List<Player>();
    [SerializeField] private PlayerRuntimeSet currentPlayers;
    [SerializeField] private SpawnPointRuntimeSet spawnPoints;

    void Awake ()
    {
        //listOfPlayers = new List<GameObject>();
        currentPlayers.OnAddItem.AddListener(AddPlayer);
        currentPlayers.OnRemoveItem.AddListener(CheckRoundOver);
        currentPlayers.OnRemoveItem.AddListener(AddKill);
    }

    private void Start()
    {
        // Making sure manager has all the players
        foreach (Player player in currentPlayers.Items)
        {
            AddPlayer(player);
        }
    }

    private void AddPlayer(Player player)
    {
        if (!allPlayers.Contains(player))
            allPlayers.Add(player);
    }

    private void CheckRoundOver(Player removedPlayer)
    {
        if (currentPlayers.Items.Count == 1)
        {
            // there is a winner
            WeHaveAWinner(currentPlayers.Items[0]);
            currentPlayers.Items[0].SetCrown(true);
            //StartCoroutine(ResetRound()); // Disabled for Demo
        }
        else
        {
            EveryBodyLoses();
            //StartCoroutine(ResetRound()); // Disabled for Demo
        }
    }

    private void AddKill(Player killedPlayer)
    {
        killedPlayer.StatTracker.AddStat(new CountStat(killedPlayer, "deaths", 1));
        killedPlayer.SetCrown(false);

        Player killer = killedPlayer.GetLastPlayerHitBy();
        if (killer == null)
            return;

        killer.StatTracker.AddStat(new CountStat(killer, "kills", 1));

        bool scoreChanged = false;
        foreach (RecordStat kills in confirmedKills)
        {
            if (kills.Player == killer)
            {
                scoreChanged = true;
                kills.ChangeScore(new RecordStat(killer, "mostKillsInARound" , kills.Value + 1));
            }
        }
        if (!scoreChanged)
            confirmedKills.Add(new RecordStat(killer, "mostKillsInARound", 1));
    }

    private void EveryBodyLoses()
    {
        Debug.Log("everybody loses");
    }

    private void WeHaveAWinner(Player player)
    {
        player.StatTracker.AddStat(new CountStat(player, "wins", 1));
        Debug.Log("we have a winner:"+player);
    }

    private IEnumerator ResetRound()
    {
        yield return new WaitForFixedUpdate();

        // Apply mostKills in a round
        foreach (RecordStat mostKills in confirmedKills)
        {
            mostKills.Player.StatTracker.AddStat(mostKills);
        }
        confirmedKills.Clear();

        spawnPoints.ResetSpawnPoints();
        // TODO: Fix setting players active/setting position
        foreach (Player player in allPlayers)
        {
            player.transform.position = spawnPoints.GetRandomUnusedSpawnPoint();
            player.gameObject.SetActive(true);
        }

        yield return null;
    }
}
