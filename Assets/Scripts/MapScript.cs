using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScript : MonoBehaviour
{
    [SerializeField] private Transform spawnPointsParent;
    [SerializeField] private SpawnPointRuntimeSet spawnPointsList;

    private List<MapLayer> layers;
    public bool ShouldShrink {get; set;}
    private float timer = 0f;
    public float layersDelay = 1f;
    public int layersToBeLeftAtTheEnd = 1;
    public Text text;
    // Start is called before the first frame update
    void Awake()
    {
        layers = new List<MapLayer>();
        layers.AddRange(transform.GetComponentsInChildren<MapLayer>());
        ShouldShrink = false;
        //timer = layersDelay;
        SetSpawnPoints();
    }

    private void SetSpawnPoints()
    {
        spawnPointsList.Items.Clear();
        foreach(Transform transform in spawnPointsParent)
        {
            spawnPointsList.AddItem(transform.position);
        }
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
        if (layers.Count > layersToBeLeftAtTheEnd)
        {
            if(!layers[0].ShouldShrink) layers[0].ShouldShrink = true;
            if(layers[0].AllTilesHaveFallen) 
            {
                text.text = "COUNTER:" + Mathf.Round(layersDelay-timer);
                if(timer > layersDelay)
                {
                    layers.RemoveAt(0);
                    timer = 0f;
                }   
                timer += Time.deltaTime;
            }
            else text.text = " ";
        }
        else 
        {
            text.text = " ";
            ShouldShrink = false;
        }
    }
}
