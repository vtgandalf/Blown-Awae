using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyCrate : MonoBehaviour
{
    [SerializeField] private PickupSpawner spawner;
    [SerializeField] private TileRuntimeSet tileList;

    private Tile parent;

    public void Awake()
    {
        if (transform.parent != null)
        {
            Tile tile = transform.parent.GetComponent<Tile>();
            if (tile != null)
                parent = tile;
        }
    }

    public void OnExplode()
    {
        if (parent != null)
            tileList.SetUsable(parent);
        spawner.SpawnRandomPowerup(transform.position);
        this.gameObject.SetActive(false);
        //GetComponent<Collider>().enabled = false;
        //Destroy(gameObject, 5f);
    }
}
