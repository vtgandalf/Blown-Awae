using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapTimerScript : MonoBehaviour
{
    public float timeLeft = 300.0f;
    public Text text;
    public MapScript map;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0) timeLeft -= Time.deltaTime;
        else 
        {
            text.text = null;
            this.gameObject.GetComponent<MapTimerScript>().enabled = false;
        }
        text.text = "COUNTER:" + Mathf.Round(timeLeft);
        if(timeLeft < 0)
        {
            map.ShouldShrink = true;
        }
    }
}
