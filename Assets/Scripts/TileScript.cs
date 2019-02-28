using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public bool HasFallen{get; set;}
    public float delay = 5f;
    // Start is called before the first frame update
    void Start()
    {
        HasFallen = false;
    }

    // Update is called once per frame
    void Update()
    {
        //not needed anymore
        /*if(HasFallen)
        {
                Destroy(this.gameObject, delay);
        }*/
        
    }
}
