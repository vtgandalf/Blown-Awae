using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    private List<GameObject> childrenTilesList;
    public bool ShouldShrink {get; set;}
    private int tileIndex = 0;
    private float timer = 0f;
    public float tilesDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        childrenTilesList = new List<GameObject>();
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
                TileFall(tileIndex);
                tileIndex++;
                timer = 0f;
            }   
            timer += Time.deltaTime;
        }
    }

    private void FillTilesList()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            childrenTilesList.Add(transform.GetChild(i).gameObject);
        }
    }

    public void TileFall(int index)
    {
        childrenTilesList[index].transform.GetComponent<Rigidbody>().isKinematic = false;
        childrenTilesList[index].transform.GetComponent<TileScript>().HasFallen = true;
    }
}
