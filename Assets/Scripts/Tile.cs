using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Rigidbody rb;
    public bool slippery = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Fall()
    {
        rb.isKinematic = false;
    }

    internal void ChangeColor(Color tileColor)
    {
        GetComponent<MeshRenderer>().material.color = tileColor;
    }

    internal void SetSlippery(bool slippery)
    {
        this.slippery = slippery;
    }
}
