using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpPlayerIndicator : MonoBehaviour
{
    public Player player;
    private Image image;
    // Update is called once per frame
    void Awake() {
        image = GetComponentInChildren<Image>();
    }
    void Update()
    {
        transform.LookAt(Camera.main.transform.position);
        if (player.bombEffect != null)
        {
            if(!image.gameObject.activeSelf) image.gameObject.SetActive(true);
            image.sprite = player.bombEffect.image;
        }
        else
        {
            image.gameObject.SetActive(false);
        }
    }
}
