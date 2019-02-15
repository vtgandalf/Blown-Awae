using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public GameObject bigBomb;
    public GameObject throwingBomb;
    public float cooldownBigBomb = 2f;
    private float cooldownTimerBigBomb;
    public float cooldownThrowingBomb = 1f;
    private float cooldownTimerThrowingBomb;
    public float throwForce = 1f;
    public float throwUpForce = 0f;
    private bool movementEnabled = true;

    private Rigidbody rb;
    public KeyboardInput input;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cooldownTimerBigBomb = cooldownBigBomb;
        cooldownTimerThrowingBomb = cooldownThrowingBomb;
    }
    
    void FixedUpdate()
    {
        Move();

        if (Input.GetKeyDown(input.throwingBomb) && cooldownTimerThrowingBomb >= cooldownThrowingBomb)
        {
            GameObject tBomb = Instantiate(throwingBomb, transform.position + transform.forward.normalized, transform.rotation);
            Vector3 direction = (transform.forward.normalized + new Vector3(0, throwUpForce, 0));
            tBomb.GetComponent<Rigidbody>().velocity = direction * throwForce;
            cooldownTimerThrowingBomb = 0f;
        }
        if (Input.GetKeyDown(input.bigBomb) && cooldownTimerBigBomb >= cooldownBigBomb)
        {
            Instantiate(bigBomb, transform.position + transform.forward.normalized, transform.rotation);
            cooldownTimerBigBomb = 0f;
        }
        cooldownTimerThrowingBomb += Time.fixedDeltaTime;
        cooldownTimerBigBomb += Time.fixedDeltaTime;
    }

    void Move()
    {
        float horizontal = input.GetHorizontal();
        float vertical = input.GetVertical();

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        if (movement != Vector3.zero)
        {
            if (movementEnabled)
                rb.MovePosition(rb.position + (movement * speed * Time.fixedDeltaTime));
            transform.forward = movement;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            movementEnabled = true;
            rb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            movementEnabled = false;
        }
    }
}
