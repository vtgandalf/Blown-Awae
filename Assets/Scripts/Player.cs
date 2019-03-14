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
    private Renderer rend;

    public Color playerColor;
    [SerializeField] private GameObject crown;
    [SerializeField] private PlayerRuntimeSet playerList;

    // Start is called before the first frame update
    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        bombInteractable = GetComponent<BombInteractable>();
        rend = GetComponent<Renderer>();
        playerList.AddItem(this);
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

    public void SetColor(Color color)
    {
        rend.material.SetColor("_Color", color);
    }

    public void SetCrown(bool active)
    {
        crown.SetActive(active);
    }

    private void OnEnable()
    {
        playerList.AddItem(this);
    }

    private void OnDisable()
    {
        playerList.RemoveItem(this);
    }

    private void OnDestroy()
    {
        playerList.RemoveItem(this);
    }
}
