using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyCrateFactory : MonoBehaviour
{
    [SerializeField] private SupplyCrate scPrefab;
    [SerializeField] private bool spawning = true;
    [SerializeField] private float yOffset = 1f;
    public float spawnInterval = 5f;
    private float spawnTimer;

    private void Start()
    {
        spawnTimer = spawnInterval;
    }
    
    void FixedUpdate()
    {
        //if (!spawning)
        //    return;

        spawnTimer -= Time.fixedDeltaTime;
        if (spawnTimer <= 0)
        {
            Tile tile = GetRandomUnusedTile();
            if (tile != null)
            {
                SupplyCrate crate = Instantiate(scPrefab, tile.transform.position + Vector3.up * yOffset, Quaternion.identity);
                crate.SetParent(tile);
            }
            //else spawning = false;
            spawnTimer = spawnInterval;
        }
    }

    private Tile GetRandomUnusedTile()
    {
        if (Tile.usableTiles.Count == 0)
            return null;

        Tile randomTile = Tile.usableTiles[Random.Range(0, Tile.usableTiles.Count - 1)];

        if (randomTile != null)
            randomTile.SetUsable(false);

        return randomTile;
    }
}
