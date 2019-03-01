using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractableType
{
    OBSTACLE,
    GROUND,
    PLAYER,
}

public class BombInteractable : MonoBehaviour
{
    public InteractableType type;
    public float weight = 0f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Explode(Vector3 direction, float force)
    {
        if (type == InteractableType.GROUND)
            return;

        force = Mathf.Max(force - weight, 0f);
        rb.AddForce(direction * force, ForceMode.VelocityChange);
    }
}
