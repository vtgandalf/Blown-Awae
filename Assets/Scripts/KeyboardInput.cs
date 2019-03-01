using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Keyboard Input", menuName = "Input/Keyboard")]
public class KeyboardInput : InputScript
{
    public KeyCode up, left, down, right;
    override public float GetHorizontal()
    {
        float horizontal = 0f;

        if (UnityEngine.Input.GetKey(right))
            horizontal += 1f;
        if (UnityEngine.Input.GetKey(left))
            horizontal -= 1f;

        return horizontal;
    }

    override public float GetVertical()
    {
        float vertical = 0f;

        if (Input.GetKey(up))
            vertical += 1f;
        if (Input.GetKey(down))
            vertical -= 1f;

        return vertical;
    }
}
