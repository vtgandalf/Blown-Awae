using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private List<AudioClip> AudioClips;
    System.Random rndm;
    // Start is called before the first frame update
    void Start()
    {
        rndm = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(int position)
    {
        if (position < AudioClips.Count)
        {
            AudioSource.clip = AudioClips[position];
            AudioSource.Play();
        }
    }

    public void PlayRandomSound()
    {
        AudioSource.clip = AudioClips[rndm.Next(0,AudioClips.Count)];
        AudioSource.Play();
    }
}
