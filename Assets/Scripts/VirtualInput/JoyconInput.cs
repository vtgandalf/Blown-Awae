using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Joystick Input", menuName = "Input/Joystick")]
public class JoyconInput : VirtualInput
{
    private int controllerNumber;
    private string horizontalAxis, verticalAxis;
    private KeyCode bigBombButton, throwingBombButton, startButton;

    private float horizontal = 0f;
    private float vertical = 0f;

    public void SetControllerNumber(int joystickIndex, bool usesPlus)
    {
        controllerNumber = joystickIndex;
        Register(usesPlus);
    }
    public void Register(bool usesPlus)
    {
        horizontalAxis = "Joy" + controllerNumber + "Horizontal";
        verticalAxis = "Joy" + controllerNumber + "Vertical";
        string bB = "Joystick"+ controllerNumber + "Button1";
        string tB = "Joystick"+ controllerNumber + "Button0";
        string start = "Joystick"+ controllerNumber + "Button" + (usesPlus ? 9 : 8);
        bigBombButton = (KeyCode)System.Enum.Parse(typeof(KeyCode), bB);
        throwingBombButton = (KeyCode)System.Enum.Parse(typeof(KeyCode), tB);
        startButton = (KeyCode)System.Enum.Parse(typeof(KeyCode), start);
    }

    public override void CheckForInput()
    {
        if (Input.GetKeyDown(bigBombButton))
        {
            BigBombHold = true;
            OnBigBombDown.Invoke();
        }
        if (Input.GetKeyUp(bigBombButton))
        {
            BigBombHold = false;
            OnBigBombUp.Invoke();
        }
        if (Input.GetKeyDown(throwingBombButton))
        {
            ThrowingBombHold = true;
            OnThrowingBombDown.Invoke();
        }
        if (Input.GetKeyUp(throwingBombButton))
        {
            ThrowingBombHold = false;
            OnThrowingBombUp.Invoke();
        }
        if (Input.GetKeyUp(startButton))
        {
            OnStartDown.Invoke();
        }
    }

    public override float GetHorizontal()
    {
        float direction = Input.GetAxis(horizontalAxis);

        if (direction == 0f)
            horizontal = 0f;
        else horizontal = Mathf.Lerp(horizontal, direction, Time.fixedDeltaTime * 4f);

        return horizontal;
    }

    public override float GetVertical()
    {
        float direction = Input.GetAxis(verticalAxis);

        if (direction == 0f)
            vertical = 0f;
        else vertical = Mathf.Lerp(vertical, direction, Time.fixedDeltaTime * 4f);

        return vertical;
    }
}
