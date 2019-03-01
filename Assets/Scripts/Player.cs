using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bomb bigBomb;
    public Bomb throwingBomb;
    public BombEffect bombEffect;

    private PlayerController playerController;

    private BombInteractable bombInteractable;

    public Color playerColor;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        bombInteractable = GetComponent<BombInteractable>();
        GetComponent<Renderer>().material.color = playerColor;
    }

    public void AddSpeed(float speed)
    {
        playerController.speed += Mathf.Max(speed, 1f);
    }

    public void AddWeight(float weight)
    {
        bombInteractable.weight += weight;
    }

    public void SetBombEffect(BombEffect bombEffect)
    {
        this.bombEffect = bombEffect;
    }
}
