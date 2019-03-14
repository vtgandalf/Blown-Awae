using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public List<Player> allPlayers = new List<Player>();
    [SerializeField] private PlayerRuntimeSet currentPlayers;
    [SerializeField] private SpawnPointRuntimeSet spawnPoints;
    [SerializeField] private ScoreTracker scoreTracker;

    void Awake ()
    {
        //listOfPlayers = new List<GameObject>();
        currentPlayers.OnAddItem.AddListener(AddPlayer);
        currentPlayers.OnRemoveItem.AddListener(CheckList);
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

    private void CheckList(Player player)
    {
        player.SetCrown(false);

        Debug.Log(currentPlayers.Items.Count);
        if(currentPlayers.Items.Count > 1)
        {
            // there are more than one player still playing
        }
        else if (currentPlayers.Items.Count == 1)
        {
            // there is a winner
            WeHaveAWinner(currentPlayers.Items[0]);
            currentPlayers.Items[0].SetCrown(true);
            ResetRound();
        }
        else
        {
            EveryBodyLoses();
            ResetRound();
        }
    }

    private void EveryBodyLoses()
    {
        Debug.Log("everybody loses");
    }

    private void WeHaveAWinner(Player player)
    {
        Debug.Log("we have a winner:"+player);
    }

    private void ResetRound()
    {
        spawnPoints.ResetSpawnPoints();
        // TODO: Fix setting players active/setting position
        foreach (Player player in allPlayers)
        {
            player.transform.position = spawnPoints.GetRandomUnusedSpawnPoint();
            player.gameObject.SetActive(true);
        }
    }
}
