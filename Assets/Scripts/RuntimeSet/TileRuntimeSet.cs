using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RuntimeSet/Tile")]
public class TileRuntimeSet : RuntimeSet<Tile>
{
    public Tile GetRandomUnusedTile()
    {
        Debug.Log(Items.Count);
        if (Items.Count == 0)
            return null;

        List<Tile> filteredList = new List<Tile>();
        foreach (Tile tile in Items)
        {
            if (tile.Empty)
                filteredList.Add(tile);
        }

        Tile randomTile = filteredList[Random.Range(0, filteredList.Count - 1)];
        return randomTile;
    }
}
