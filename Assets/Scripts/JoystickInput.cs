using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Joystick Input", menuName = "Input/Joystick")]
public class JoystickInput : InputScript
{
    private int controllerNumber;
    private string horizontalAxis, verticalAxis, bB, tB;
 
    override public InputScript(int joystickIndex)
    {
        controllerNumber = joystickIndex;
        Register();
    }
    public void Register()
    {
        horizontalAxis = "J" + controllerNumber + "Horizontal";
        verticalAxis = "J" + controllerNumber + "Vertical";
        bB = "Joystick"+ controllerNumber + "Button1";
        tB = "Joystick"+ controllerNumber + "Button0";
        bigBomb = (KeyCode)System.Enum.Parse(typeof(KeyCode), bB);
        throwingBomb = (KeyCode)System.Enum.Parse(typeof(KeyCode), tB);
    }

    
    override public float GetHorizontal()
    {
        return Input.GetAxisRaw(horizontalAxis);
    }

    override public float GetVertical()
    {
        return Input.GetAxisRaw(verticalAxis);
    }
}
