using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bomb Settings", menuName = "Settings/Bomb")]
public class BombSettings : ScriptableObject
{
    public float cooldownBigBomb, cooldownThrowingBomb;
    public float throwForce, throwUpForce;
    public float chargeRate, maxCharge;
    public int maxBounces;
}
