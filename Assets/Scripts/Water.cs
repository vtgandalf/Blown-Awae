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
        Debug.Log(other.gameObject);
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
