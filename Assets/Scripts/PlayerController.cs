using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player player;

    public float rayLength = 5f;
    public float speed = 1f;

    public BombSettings bombSettings;
    public KeyboardInput input;

    private Rigidbody rb;
    private float distToGround;
    private float cooldownTimerBigBomb;
    private float cooldownTimerThrowingBomb;
    private float throwCharge = 0f;

    void Start()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
        CapsuleCollider capCol = GetComponent<CapsuleCollider>();
        distToGround = capCol.height / 2 + capCol.radius;
        distToGround = capCol.bounds.extents.y;
        cooldownTimerBigBomb = bombSettings.cooldownBigBomb;
        cooldownTimerThrowingBomb = bombSettings.cooldownThrowingBomb;
    }

    void FixedUpdate()
    {
        Move();

        if (Input.GetKey(input.throwingBomb) && throwCharge < bombSettings.maxCharge && cooldownTimerThrowingBomb >= bombSettings.cooldownThrowingBomb)
        {
            throwCharge += Time.fixedDeltaTime * bombSettings.chargeRate;
            throwCharge = Mathf.Min(throwCharge, bombSettings.maxCharge);
            Debug.Log(throwCharge);
        }
        if (Input.GetKeyUp(input.throwingBomb) && cooldownTimerThrowingBomb >= bombSettings.cooldownThrowingBomb)
        {
            ThrowingBomb bomb = Instantiate(player.throwingBomb, transform.position + transform.forward, transform.rotation) as ThrowingBomb;
            bomb.Throw(bombSettings.throwForce + throwCharge, bombSettings.throwUpForce);

            throwCharge = 0f;
            cooldownTimerThrowingBomb = 0f;

            bomb.Owner = gameObject;
        }
        if (Input.GetKeyDown(input.bigBomb) && cooldownTimerBigBomb >= bombSettings.cooldownBigBomb)
        {
            Bomb bomb = Instantiate(player.bigBomb, transform.position + transform.forward, transform.rotation);

            cooldownTimerBigBomb = 0f;

            bomb.Owner = gameObject;
        }
        cooldownTimerThrowingBomb += Time.fixedDeltaTime;
        cooldownTimerBigBomb += Time.fixedDeltaTime;
    }

    private void Move()
    {
        float horizontal = input.GetHorizontal();
        float vertical = input.GetVertical();

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        // Calculates the next position the player is going to be next frame
        Vector3 nextPos = rb.position + (movement.normalized * speed * Time.fixedDeltaTime);
        if (movement != Vector3.zero)
        {
            transform.forward = movement;
            if (CanMove(nextPos))
            {
                rb.velocity = Vector3.zero;
                rb.MovePosition(nextPos);
            }
        }
    }

    private bool CanMove(Vector3 nextPos)
    {
        return IsGrounded(transform.position) && IsGrounded(nextPos);
    }

    private bool IsGrounded(Vector3 startPos)
    {
        // Checks if there is ground under the player based on the given position
        if (Physics.Raycast(startPos, Vector3.down, out RaycastHit hit, distToGround + 0.01f))
        {
            return true;
        }
        return false;
    }
}
