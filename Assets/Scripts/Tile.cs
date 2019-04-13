using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public static List<Tile> usableTiles = new List<Tile>();

    public bool Empty;

    private Rigidbody rb;
    public bool slippery = false;

    private bool falling = false;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        SetUsable(true);
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
        SetUsable(false);
        StartCoroutine(LateDeactivate(3));        
    }

    public void ChangeColor(Color tileColor)
    {
        GetComponent<MeshRenderer>().material.color = tileColor;
    }

    public void SetSlippery(bool slippery)
    {
        this.slippery = slippery;
    }

    IEnumerator LateDeactivate(int sec)
    {
        yield return new WaitForSeconds(sec);
        gameObject.SetActive(false);
    }

    public void SetUsable(bool usable)
    {
        if (gameObject.activeSelf && usable && !usableTiles.Contains(this))
            usableTiles.Add(this);
        else if (usableTiles.Contains(this)) usableTiles.Remove(this);
    }
}
