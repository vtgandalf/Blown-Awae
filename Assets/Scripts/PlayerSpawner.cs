using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Settings", menuName = "Player/Settings")]
public class PlayerSpawner : ScriptableObject
{
    public List<object[]> listOfSettings;
    int lastWinner;
    public List<Color> listOfColors;
    private int playersNumber = 0;


    private void OnEnable() {
        if(listOfSettings == null) listOfSettings = new List<object[]>();
        Debug.Log(listOfSettings);
        playersNumber = 0;
    }

    public void SetUpPlayerColor(Player player, int ControllerID)
    {
        int counter = 0;
        foreach (object[] x in this.listOfSettings)
        {
            if((int)x[0] == ControllerID)
            {
                player.SetColor((Color)x[1]);
                if((int)x[0] == lastWinner) player.SetCrown(true);
                playersNumber++;
            }
            else counter++;
        }
        if(counter == listOfSettings.Count) 
        {
            object[] obj = {ControllerID, listOfColors[playersNumber]};
            listOfSettings.Add(obj);
            player.SetColor(listOfColors[playersNumber]);
            playersNumber++;
        }
    }
    public void SetWinner(int nbr)
        {
            lastWinner = nbr;
        }
}
