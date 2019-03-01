using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyCrate : MonoBehaviour
{
    public PickupSpawner spawner;

    public void OnExplode()
    {
        spawner.SpawnRandomPowerup(transform.position);
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 5f);
    }
}
