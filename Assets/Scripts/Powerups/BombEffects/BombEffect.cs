using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : ScriptableObject
{
    public Player Owner;

    public virtual void Activate(List<BombInteractable> hits) { }
}
