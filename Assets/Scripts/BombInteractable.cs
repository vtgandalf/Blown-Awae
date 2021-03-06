﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractableType
{
    OBSTACLE,
    GROUND,
    PLAYER,
    BOMB
}

public class BombInteractable : MonoBehaviour
{
    public InteractableType type;
    public float weight = 0f;
    public Player lastPlayerHitBy; // Keeps track of which player hit this object last

    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Explode(Vector3 direction, float force, Player owner = null)
    {
        if (owner != null)
            lastPlayerHitBy = owner;

        if (type == InteractableType.GROUND)
            return;

        if (type == InteractableType.OBSTACLE)
        {
            SupplyCrate crate = GetComponent<SupplyCrate>();
            if (crate)
            {
                crate.OnExplode();
            }
        }

        force = Mathf.Max(force - weight, 0f);
        rb.AddForce(direction * force, ForceMode.VelocityChange);
    }
}
