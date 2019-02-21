using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int rayLength = 1;
    public float speed = 1f;

    private Vector3 downVector;
    private Vector3 prevPosition;
    private Rigidbody rb;
    Collider childCollider;
    public Collider groundCollider;

    public BombSettings bombSettings;
    public KeyboardInput input;
    public GameObject bigBomb;
    public GameObject throwingBomb;
    private float cooldownTimerBigBomb;
    private float cooldownTimerThrowingBomb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cooldownTimerBigBomb = bombSettings.cooldownBigBomb;
        cooldownTimerThrowingBomb = bombSettings.cooldownThrowingBomb;
        childCollider = transform.GetChild(0).GetComponent<Collider>();
        if (childCollider == null) Debug.Log("could not get collider");
    }

    void FixedUpdate()
    {
        UpdateVectors();
        if (CollisionWithTheGround())
        {
            if (RayCastDown(rayLength)) Move();
            else
            {
                transform.position = prevPosition;
            }
        }

        if (Input.GetKeyDown(input.throwingBomb) && cooldownTimerThrowingBomb >= bombSettings.cooldownThrowingBomb)
        {
            GameObject tBombObj = Instantiate(throwingBomb, transform.position + transform.forward.normalized, transform.rotation);
            Vector3 direction = transform.forward.normalized + new Vector3(0, bombSettings.throwUpForce, 0);
            tBombObj.GetComponent<Rigidbody>().velocity = direction * bombSettings.throwForce;

            cooldownTimerThrowingBomb = 0f;

            ThrowingBomb tBomb = tBombObj.GetComponent<ThrowingBomb>();
            tBomb.Owner = gameObject;
        }
        if (Input.GetKeyDown(input.bigBomb) && cooldownTimerBigBomb >= bombSettings.cooldownBigBomb)
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
            rb.MovePosition(rb.position + (movement * speed * Time.fixedDeltaTime));
            transform.forward = movement;
        }
    }

    bool RayCastDown(float rayLenght)
    {
        if (Physics.Raycast(transform.position, downVector, rayLenght))
        {
            prevPosition = transform.position;
            return true;
        }
        else
        {
            return false;
        }
    }

    bool CollisionWithTheGround()
    {
        if (childCollider.bounds.Intersects(groundCollider.bounds))
        {
            return true;
        }
        else return false;
    }

    private void UpdateVectors()
    {
        downVector = transform.TransformDirection(Vector3.down);
    }
}
