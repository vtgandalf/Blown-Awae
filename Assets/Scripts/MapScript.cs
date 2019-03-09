using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    private List<MapLayer> layers;
    public bool ShouldShrink {get; set;}
    private float timer = 0f;
    public float layersDelay = 1f;
    public int layersToBeLeftAtTheEnd = 1;
    // Start is called before the first frame update
    void Start()
    {
        layers = new List<MapLayer>();
        layers.AddRange(transform.GetComponentsInChildren<MapLayer>());
        ShouldShrink = false;
        //timer = layersDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if(ShouldShrink)
        {
            DropNextLayer();
        }
    }

    public void DropNextLayer()
    {
        if (layers.Count > 1)
        {
            if(!layers[0].ShouldShrink) layers[0].ShouldShrink = true;
            if(layers[0].AllTilesHaveFallen) 
            {
                if(timer > layersDelay)
                {
                    layers.RemoveAt(0);
                    timer = 0f;
                }   
                timer += Time.deltaTime;
            }
        }
        else 
        {
            ShouldShrink = false;
        }
    }
}
