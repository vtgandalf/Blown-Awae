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

    private void OnCollisionEnter(Collision other) {
        Debug.Log("collider");
        if (other.collider.gameObject.layer == 10)
        {
            Debug.Log("player");
            AudioPlayer.PlaySound(0);
        }
        if (other.collider.gameObject.layer == 11)
        {
            Debug.Log("bomb");
            AudioPlayer.PlaySound(1);
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("collider");
        if (other.gameObject.layer == 10)
        {
            Debug.Log("player");
            AudioPlayer.PlaySound(0);
        }
        if (other.gameObject.layer == 11)
        {
            Debug.Log("bomb");
            AudioPlayer.PlaySound(1);
        }
    }
}
