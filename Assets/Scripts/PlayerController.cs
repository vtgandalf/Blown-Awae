using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rayLength = 5f;
    public float speed = 1f;
    public Color playerColor;

    public BombSettings bombSettings;
    public KeyboardInput input;
    public GameObject bigBomb;
    public GameObject throwingBomb;

    private Rigidbody rb;
    private float cooldownTimerBigBomb;
    private float cooldownTimerThrowingBomb;
    private float throwCharge = 0f;
    private bool canMove = true;

    /*private void OnValidate()
    {
        GetComponent<Renderer>().sharedMaterial.color = playerColor;
    }*/

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            GameObject tBombObj = Instantiate(throwingBomb, transform.position + transform.forward, transform.rotation);
            Vector3 direction = transform.forward + new Vector3(0, bombSettings.throwUpForce, 0);
            tBombObj.GetComponent<Rigidbody>().velocity = direction * (bombSettings.throwForce + throwCharge);

            throwCharge = 0f;
            cooldownTimerThrowingBomb = 0f;

            ThrowingBomb tBomb = tBombObj.GetComponent<ThrowingBomb>();
            tBomb.Owner = gameObject;
        }
        if (Input.GetKeyDown(input.bigBomb) && cooldownTimerBigBomb >= bombSettings.cooldownBigBomb)
        {
            Instantiate(bigBomb, transform.position + transform.forward, transform.rotation);
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
        Vector3 nextPos = rb.position + (movement * speed * Time.fixedDeltaTime);
        if (movement != Vector3.zero)
        {
            transform.forward = movement;
            if (canMove && Physics.Raycast(nextPos, Vector3.down))
            {
                rb.MovePosition(nextPos);
            }
        }
    }
}
