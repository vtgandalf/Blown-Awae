using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private List<GameObject> listOfPlayers;
    // Start is called before the first frame update
    void Awake ()
    {
        listOfPlayers = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlayerToTheList(GameObject obj)
    {
        listOfPlayers = new List<GameObject>();

        listOfPlayers.Add(obj);
    }

    public void UpdatePlayerList(GameObject obj)
    {
        listOfPlayers.Remove(obj);
        CheckList();
    }

    private void CheckList()
    {
        Debug.Log(listOfPlayers.Count);
        if(listOfPlayers.Count > 1)
        {
            // there are more than one player still playing
        }
        else if (listOfPlayers.Count == 1)
        {
            // there is a winner
            WeHaveAWinner(listOfPlayers[0]);
        }
        else
        {
            EveryBodyLoses();
        }
    }
    private void EveryBodyLoses()
    {
        Debug.Log("everybody loses");
    }

    private void WeHaveAWinner(GameObject obj)
    {
        Debug.Log("we have a winner:"+obj);
    }
}
