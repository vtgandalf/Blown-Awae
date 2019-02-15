using System;
using UnityEngine;

public class BigBomb : MonoBehaviour
{
    public BombData data;
    private float timeActive = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Projector projector = GetComponentInChildren<Projector>();
        projector.orthographicSize = data.radius;
    }

    // Update is called once per frame
    void Update()
    {
        timeActive += Time.deltaTime;
        if (timeActive >= data.lifetime) {
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
                rb.velocity = direction * data.force;
            }
        }

        Destroy(gameObject);
    }
}
