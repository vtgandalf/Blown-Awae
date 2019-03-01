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
    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        bombInteractable = GetComponent<BombInteractable>();
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

    public void SetVirtualInput(VirtualInput vi)
    {
        playerController.SetVirtualInput(vi);
    }
}
