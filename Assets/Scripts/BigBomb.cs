using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBomb : MonoBehaviour
{
    public float lifetime = 3f;
    private float timeActive = 0f;
    public float explosionRadius = 2f;
    public float explosionForce = 10f;
    public float explosionUpForce = 1f;

    private bool exploded = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeActive += Time.deltaTime;
        if (timeActive >= lifetime && !exploded)
            Explode();
    }

    private void Explode()
    {
        exploded = true;

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpForce, ForceMode.Impulse);
            }
        }

        Destroy(gameObject);
    }
}
