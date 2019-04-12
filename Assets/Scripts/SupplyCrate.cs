using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyCrate : MonoBehaviour
{
    [SerializeField] private PickupSpawner spawner;
    [SerializeField] private TileRuntimeSet tileList;

    private Tile parent;

    public void SetParent(Tile parent)
    {
        if (this.parent == null)
        {
            parent.Empty = false;
            parent.SetUsable(false);
            this.parent = parent;
        }
    }

    public void OnExplode()
    {
        if (parent != null)
        {
            parent.Empty = true;
            parent.SetUsable(true);
        }
        spawner.SpawnRandomPowerup(transform.position);
        gameObject.SetActive(false);
    }
}
