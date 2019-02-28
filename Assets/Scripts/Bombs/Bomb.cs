using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public BombData data;
    private float timeActive = 0f;
    public GameObject Owner { get; set; }

    // Start is called before the first frame update
    protected void Start()
    {
        Projector projector = GetComponentInChildren<Projector>();
        if (projector)
        {
            projector.orthographicSize = data.radius;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeActive += Time.deltaTime;
        if (timeActive >= data.lifetime)
        {
            Explode();
        }
    }


    protected virtual void Explode()
    {
        GameObject effect = Instantiate(data.explosionEffect, transform.position, transform.rotation);
        Destroy(effect, 1f);

        Collider[] colliders = Physics.OverlapSphere(transform.position, data.radius);
        foreach (Collider hit in colliders)
        {
            BombInteractable bi = hit.GetComponent<BombInteractable>();
            if (bi)
            {
                Vector3 difference = bi.transform.position - transform.position;
                difference.y = data.upForce;
                Vector3 direction = Vector3.Normalize(difference);
                
                bi.Explode(direction, data.force);
            }
        }

        Destroy(gameObject);
    }
}
