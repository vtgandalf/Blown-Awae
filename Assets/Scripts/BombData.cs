using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BombData")]
public class BombData : ScriptableObject
{
    public float lifetime;
    public float radius;
    public float force;
    public float upForce;
}
