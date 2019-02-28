using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBigCollider : MonoBehaviour
{
    private void OnTriggerExit(Collider other) {
        other.gameObject.SetActive(false);
        if(other.gameObject.GetComponent<Player>()!=null)
        {
            Debug.Log("player has died!");
        }
    }
}
