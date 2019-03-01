using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingBomb : Bomb
{
    private int bounces;

    public void Throw(float force, float upForce)
    {
        Vector3 direction = transform.forward + new Vector3(0, upForce, 0);
        GetComponent<Rigidbody>().velocity = direction * (force);
        bounces = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        BombInteractable bi = collision.gameObject.GetComponent<BombInteractable>();
        if (bi != null && bi.type == InteractableType.GROUND)
        {
            bounces++;
            if (bounces >= 3)
            {
                Explode();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        BombInteractable bi = other.gameObject.GetComponent<BombInteractable>();
        if (bi != null && bi.type != InteractableType.GROUND)
        {
            if (bi.GetComponent<Player>() != Owner)
                Explode();
        }
    }
}
