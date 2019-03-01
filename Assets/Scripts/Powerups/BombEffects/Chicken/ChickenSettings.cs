using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chicken Settings", menuName = "Settings/Chicken")]
public class ChickenSettings : ScriptableObject
{
    public Chicken chickenPrefab;

    public int chickensToSpawn;
    public float spawnInterval;
    public float spawnDistance;
    public float chickenSpeed;
    public float chickenForce;
}
