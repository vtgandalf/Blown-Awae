﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Powerup powerup;

    void Update()
    {
        transform.Rotate(new Vector3(1, 1, 2));
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.StatTracker.AddStat(new CountStat(player, "pickups", 1));
            powerup.Apply(player);
            Destroy(gameObject);
        }
    }
}
