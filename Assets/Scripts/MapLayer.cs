using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLayer : MonoBehaviour
{
     private List<Tile> tiles;
    public bool ShouldShrink {get; set;}

    public bool AllTilesHaveFallen { get; set; }
    private float timer = 0f;
    public float tilesDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        tiles = new List<Tile>();
        tiles.AddRange(transform.GetComponentsInChildren<Tile>());
        ShouldShrink = false;
        AllTilesHaveFallen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ShouldShrink)
        {
            if(timer > tilesDelay)
            {
                DropNextTile();
                timer = 0f;
            }   
            timer += Time.deltaTime;
        }
    }

    public void DropNextTile()
    {
        if (tiles.Count > 0)
        {
            tiles[0].Fall();
            tiles.RemoveAt(0);
        }
        else 
        {
            if(ShouldShrink) ShouldShrink = false;
            if(AllTilesHaveFallen != true) AllTilesHaveFallen = true;
        }
    }
}
