using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : ScriptableObject
{
    public virtual void Activate(List<BombInteractable> hits) { }
}
