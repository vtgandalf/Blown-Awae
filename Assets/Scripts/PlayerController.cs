using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public GameObject bigBomb;
    public float cooldownBigBomb = 2f;
    private float cooldownTimerBigBomb;

    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cooldownTimerBigBomb = cooldownBigBomb;
    }
    
    void FixedUpdate()
    {
        Move();

        if (Input.GetKeyDown("space") && cooldownTimerBigBomb >= cooldownBigBomb)
        {
            Instantiate(bigBomb, transform.position, transform.rotation);
            cooldownTimerBigBomb = 0f;
        }
        cooldownTimerBigBomb += Time.fixedDeltaTime;
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        if (movement != Vector3.zero)
        {
            rb.MovePosition(rb.position + (movement * speed * Time.fixedDeltaTime));
            transform.forward = movement;
        }
    }
}
