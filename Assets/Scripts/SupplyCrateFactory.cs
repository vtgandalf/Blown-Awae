using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyCrateFactory : MonoBehaviour
{
    [SerializeField] private SupplyCrate scPrefab;
    [SerializeField] private TileRuntimeSet activeTiles;
    [SerializeField] private float yOffset = 1f;
    public float spawnInterval = 5f;
    private float spawnTimer;
    public bool spawning = true;

    private void Start()
    {
        spawnTimer = spawnInterval;
    }
    
    void FixedUpdate()
    {
        if (!spawning)
            return;

        spawnTimer -= Time.fixedDeltaTime;
        if (spawnTimer <= 0)
        {
            Tile tile = activeTiles.GetRandomUnusedTile();
            if (tile != null)
            {
                activeTiles.SetUnusable(tile);
                Instantiate(scPrefab, tile.transform.position + Vector3.up * yOffset, Quaternion.identity, tile.transform);
            }
            else spawning = false;
            spawnTimer = spawnInterval;
        }
    }
}
