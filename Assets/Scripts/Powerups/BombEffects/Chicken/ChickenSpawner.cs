using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawner : MonoBehaviour
{
    public ChickenSettings chickenSettings;
    private int chickensLeft;

    private float spawnTimer = 0f;

    public void SetChickenSettings(ChickenSettings chickenSettings)
    {
        this.chickenSettings = chickenSettings;
        chickensLeft = chickenSettings.chickensToSpawn;
    }

    void FixedUpdate()
    {
        if (spawnTimer >= chickenSettings.spawnInterval)
        {
            spawnTimer = 0f;
            SpawnChicken();
        }

        spawnTimer += Time.fixedDeltaTime;
    }
    
    private void SpawnChicken()
    {
        Vector3 spawnPos = transform.position + Random.insideUnitSphere.normalized * chickenSettings.spawnDistance;

        Chicken chicken = Instantiate(chickenSettings.chickenPrefab, spawnPos, Quaternion.identity);
        chicken.SetTarget(transform.parent.GetComponent<BombInteractable>());
        chicken.SetValues(chickenSettings.chickenSpeed, chickenSettings.chickenForce);

        chickensLeft--;

        if (chickensLeft <= 0)
        {
            Destroy(gameObject);
        }
    }
}
