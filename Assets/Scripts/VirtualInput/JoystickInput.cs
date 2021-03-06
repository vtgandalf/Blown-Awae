﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Joystick Input", menuName = "Input/Joystick")]
public class JoystickInput : VirtualInput
{
    private int controllerNumber;
    private string horizontalAxis, verticalAxis;
    private KeyCode bigBombButton, throwingBombButton, startButton;

    public void SetControllerNumber(int joystickIndex)
    {
        controllerNumber = joystickIndex;
        Register();
    }
    public void Register()
    {
        horizontalAxis = "J" + controllerNumber + "Horizontal";
        verticalAxis = "J" + controllerNumber + "Vertical";
        string bB = "Joystick"+ controllerNumber + "Button1";
        string tB = "Joystick"+ controllerNumber + "Button0";
        string start = "Joystick"+ controllerNumber + "Button7";
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
        return Input.GetAxis(horizontalAxis);
    }

    public override float GetVertical()
    {
        return Input.GetAxis(verticalAxis);
    }
}
