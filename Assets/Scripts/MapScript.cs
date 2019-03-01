using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    private List<Tile> tiles;
    public bool ShouldShrink {get; set;}
    private int tileIndex = 0;
    private float timer = 0f;
    public float tilesDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        tiles = new List<Tile>();
        FillTilesList();
        ShouldShrink = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ShouldShrink)
        {
            if(timer > tilesDelay)
            {
                if (tileIndex < tiles.Count)
                {
                    TileFall(tileIndex);
                    tileIndex++;
                    timer = 0f;
                }
                else ShouldShrink = false;
            }   
            timer += Time.deltaTime;
        }
    }

    private void FillTilesList()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            tiles.Add(transform.GetChild(i).GetComponent<Tile>());
        }
    }

    public void TileFall(int index)
    {
        if(tiles[index]!=null)tiles[index].Fall();
    }
}
