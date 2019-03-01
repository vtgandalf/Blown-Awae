using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    private BombInteractable target;
    private float speed;
    private float force;

    void FixedUpdate()
    {
        transform.LookAt(target.transform);
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    public void SetTarget(BombInteractable target)
    {
        this.target = target;
    }

    public void SetValues(float speed, float force)
    {
        this.speed = speed;
        this.force = force;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == target.GetComponent<Collider>())
        {
            Vector3 direction = other.transform.position - transform.position;
            target.Explode(direction, force);
            Destroy(gameObject);
        }
    }
}
