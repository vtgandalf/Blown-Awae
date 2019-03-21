using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Rigidbody rb;
    public bool slippery = false;

    private bool falling = false;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (falling)
        {
            rb.MovePosition(transform.position + Vector3.down * Time.fixedDeltaTime);
        }
    }

    public void Fall()
    {
        transform.parent = null;
        rb.isKinematic = false;
        falling = true;
    }

    public void ChangeColor(Color tileColor)
    {
        GetComponent<MeshRenderer>().material.color = tileColor;
    }

    public void SetSlippery(bool slippery)
    {
        this.slippery = slippery;
    }
}
