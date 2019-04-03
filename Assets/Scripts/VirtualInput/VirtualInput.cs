using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class VirtualInput : ScriptableObject
{
    public UnityEvent OnBigBombDown = new UnityEvent();
    public UnityEvent OnBigBombUp = new UnityEvent();
    public UnityEvent OnThrowingBombDown = new UnityEvent();
    public UnityEvent OnThrowingBombUp = new UnityEvent();
    public UnityEvent OnStartDown = new UnityEvent();
    public bool BigBombHold { get; protected set; } = false;
    public bool ThrowingBombHold { get; protected set; } = false;

    public abstract float GetHorizontal();

    public abstract float GetVertical();

    public abstract void CheckForInput();
}
