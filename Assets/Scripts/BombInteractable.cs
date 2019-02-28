using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombInteractable : MonoBehaviour
{
    public float weight = 0f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Explode(Vector3 direction, float force)
    {
        force = Mathf.Max(force - weight, 0f);
        rb.AddForce(direction * force, ForceMode.VelocityChange);
    }
}
