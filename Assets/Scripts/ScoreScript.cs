using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> listOfPlayers;
    // Start is called before the first frame update
    void Start()
    {
        listOfPlayers = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlayerToTheList(GameObject obj)
    {
        listOfPlayers.Add(obj);
    }

    public void UpdatePlayerList(GameObject obj)
    {
        listOfPlayers.Remove(obj);   
    }
}
