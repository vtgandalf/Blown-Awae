using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingBomb : Bomb
{
    private int maxBounces = 3;
    private int bounces;

    public void Throw(float force, float upForce, int maxBounces = 3)
    {
        Vector3 direction = transform.forward + new Vector3(0, upForce, 0);
        GetComponent<Rigidbody>().velocity = direction * (force);

        this.maxBounces = maxBounces;
        bounces = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            bounces++;
            if (bounces >= maxBounces)
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
