using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombEffectUI : MonoBehaviour
{
    [SerializeField]private Player parent;
    [SerializeField]private Image Image;
    private void Start() {
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        if(parent.bombEffect == null) Image.enabled = false;
        else 
        {
            if(Image.enabled == false) Image.enabled = true;
            Image.sprite = parent.bombEffect.Image;
        }
    }
}
