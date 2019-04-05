using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private AudioPlayer AudioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(!other.isTrigger) 
        {
            if (other.gameObject.layer == 10)
            {
                AudioPlayer.PlaySound(0);
            }
            if (other.gameObject.layer == 11)
            {
                AudioPlayer.PlaySound(1);
            }
        }
    }
}
