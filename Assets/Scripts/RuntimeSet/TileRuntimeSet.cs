using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RuntimeSet/Tile")]
public class TileRuntimeSet : RuntimeSet<Tile>
{
    private List<Tile> unusedTiles;

    private void OnEnable()
    {
        ResetTiles();
        OnAddItem.AddListener(SetUsable);
        OnRemoveItem.AddListener(SetUnusable);
    }

    private void OnDisable()
    {
        OnAddItem.RemoveAllListeners();
        OnRemoveItem.RemoveAllListeners();
    }

    public void SetUsable(Tile tile)
    {
        if (Items.Contains(tile) && !unusedTiles.Contains(tile))
        {
            unusedTiles.Add(tile);
        }
    }

    public void SetUnusable(Tile tile)
    {
        if (unusedTiles.Contains(tile))
        {
            unusedTiles.Remove(tile);
        }
    }

    public void ResetTiles()
    {
        unusedTiles = new List<Tile>(Items);
    }

    public Tile GetRandomUnusedTile()
    {
        Debug.Log(unusedTiles.Count);
        if (unusedTiles.Count == 0)
            return null;

        Tile tile = unusedTiles[Random.Range(0, unusedTiles.Count - 1)];
        SetUnusable(tile);
        return tile;
    }
}
