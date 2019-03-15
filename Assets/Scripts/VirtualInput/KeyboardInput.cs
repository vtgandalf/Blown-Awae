using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Keyboard Input", menuName = "Input/Keyboard")]
public class KeyboardInput : VirtualInput
{
    public KeyCode up, left, down, right, bigBomb, throwingBomb;
    public float sensitivity = 1f;

    private float horizontal = 0f;
    private float vertical = 0f;

    public override void FixedUpdate()
    {
        if (Input.GetKeyDown(bigBomb))
        {
            BigBombHold = true;
            OnBigBombDown.Invoke();
        }
        if (Input.GetKeyUp(bigBomb))
        {
            BigBombHold = false;
            OnBigBombUp.Invoke();
        }
        if (Input.GetKeyDown(throwingBomb))
        {
            ThrowingBombHold = true;
            OnThrowingBombDown.Invoke();
        }
        if (Input.GetKeyUp(throwingBomb))
        {
            ThrowingBombHold = false;
            OnThrowingBombUp.Invoke();
        }
    }

    override public float GetHorizontal()
    {
        float direction = 0f;

        if (Input.GetKey(right))
            direction += 1f;
        if (Input.GetKey(left))
            direction -= 1f;

        if (direction == 0f)
            horizontal = 0f;
        else horizontal = Mathf.Lerp(horizontal, direction, Time.fixedDeltaTime * sensitivity);

        return horizontal;
    }

    override public float GetVertical()
    {
        float direction = 0f;

        if (Input.GetKey(up))
            direction += 1f;
        if (Input.GetKey(down))
            direction -= 1f;

        if (direction == 0f)
            vertical = 0f;
        else vertical = Mathf.Lerp(vertical, direction, Time.fixedDeltaTime * sensitivity);

        return vertical;
    }
}
