using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingBomb : MonoBehaviour
{
    public BombData data;
    private int bounces = 0;

    void Start()
    {
        Projector projector = GetComponentInChildren<Projector>();
        projector.orthographicSize = data.radius;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            bounces++;
        } else Explode();
        if (bounces >= 3)
        {
            Explode();
        }
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, data.radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb)
            {
                Vector3 difference = rb.position - transform.position;
                difference.y = data.upForce;
                Vector3 direction = Vector3.Normalize(difference);
                rb.AddForce(direction * data.force, ForceMode.VelocityChange);
            }
        }

        Destroy(gameObject);
    }
}
