using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int rayLenght = 1;
    public float speed = 1f;
    private Vector3 downVector;
    private Vector3 position;
    private Vector3 prevPosition;
    private Rigidbody rb;
    Collider childCollider;
    public Collider groundCollider;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        childCollider = this.transform.GetChild(0).GetComponent<Collider>();
        if (childCollider == null) Debug.Log("could not get collider");
    }
    
    void FixedUpdate()
    {
        UpdateVectors();
        if(CollisionWithTheGround()){
            if(RayCastDown(rayLenght)) Move();
            else{
                transform.position = prevPosition;
            }
        }
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

    bool RayCastDown(float rayLenght)
    {
        if(Physics.Raycast(transform.position, downVector, rayLenght)) 
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
            Debug.Log("Over the ground");
            return true;
        }
        else
        {
            Debug.Log("Not over the ground");
            return false;
        }
    }

    private void UpdateVectors()
    {
        position = transform.position;
        downVector = this.transform.TransformDirection(Vector3.down);
    }
}
