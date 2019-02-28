using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBigCollider : MonoBehaviour
{
    public ScoreScript scoringSystem;
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.GetComponent<Player>()!=null) scoringSystem.UpdatePlayerList(other.gameObject);
        other.gameObject.SetActive(false);
    }
}
