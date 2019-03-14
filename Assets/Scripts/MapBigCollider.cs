using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBigCollider : MonoBehaviour
{
    //public ScoreScript scoringSystem;
    public PlayerRuntimeSet playerList;

    private void OnTriggerExit(Collider other) {
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null)
            playerList.RemoveItem(player);//scoringSystem.UpdatePlayerList(other.gameObject);
        other.gameObject.SetActive(false);
    }
}
