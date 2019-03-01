using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pickup Spawner", menuName = "Pickup Spawner")]
public class PickupSpawner : ScriptableObject
{
    public Pickup[] pickupPrefabs;

    public void SpawnRandomPowerup(Vector3 spawnPos)
    {
        Pickup powerup = pickupPrefabs[Random.Range(0, pickupPrefabs.Length)];
        Instantiate(powerup, spawnPos, Quaternion.identity);
    }
}
