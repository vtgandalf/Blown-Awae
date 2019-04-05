using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class CameraShake : ScriptableObject
{
    public class ShakeEvent : UnityEvent<float, float> { }

    public ShakeEvent CameraShakeEvent = new ShakeEvent();
}
